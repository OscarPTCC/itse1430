/*
 * ITSE 1430
 * Oscar Peinado-Rojo
 */
using System;
using System.Data;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Nile.Stores.Sql
{
    /// <summary>Base class for product database.</summary>
    public class SqlProductDatabase : ProductDatabase
    {        
        public SqlProductDatabase ()
        {
        }

        public SqlProductDatabase ( string connString ) : this()
        {
            _connectionString = connString;
        }

        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected override Product AddCore ( Product product )
        {
            using (var connection = OpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "AddProduct";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@IsDiscontinued", product.IsDiscontinued);

                var result = command.ExecuteScalar();
                var id = Convert.ToInt32(result);

                product.Id = id;
                return product;
            };
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        protected override Product GetCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetProduct";
                command.CommandType = CommandType.StoredProcedure;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var productId = reader.GetInt32(0);
                        if (productId == id)
                        {
                            return new Product() {
                                Id = productId,
                                Name = reader.GetString(1),
                                Description = reader.GetString(2),
                                Price = reader.GetFieldValue<decimal>(3),
                                IsDiscontinued = reader.GetFieldValue<bool>(4),
                            };
                        };
                    };
                };
            };

            return null;
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        protected override IEnumerable<Product> GetAllCore ()
        {
            var ds = new DataSet();

            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("GetAllProducts", connection);
                command.CommandType = CommandType.StoredProcedure;

                var da = new SqlDataAdapter() {
                    SelectCommand = command
                };

                da.Fill(ds);
            };

            var table = ds.Tables.Count > 0 ? ds.Tables[0] : null;
            if (table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    yield return new Product() {
                        Id = Convert.ToInt32(row[0]),
                        Name = row["name"].ToString(),
                        Description = row.Field<string>("description"),
                        Price = row.Field<decimal>("Price"),
                        IsDiscontinued = row.Field<bool>("IsDiscontinued"),
                        
                    };
                };
            };
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        protected override void RemoveCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "RemoveProduct";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            };
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected override Product UpdateCore ( Product existing, Product product )
        {
            using (var connection = OpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "UpdateProduct";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@description", product.Description);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                command.ExecuteNonQuery();
                return product;
            };
        }
        
        //Find a product by ID
        private Product FindProduct ( int id )
        {
            throw new NotImplementedException();
        }

        private SqlConnection OpenConnection ()
        {
            var conn = new SqlConnection(_connectionString);

            conn.Open();
            return conn;
        }

        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
        private readonly string _connectionString;
    }
}
