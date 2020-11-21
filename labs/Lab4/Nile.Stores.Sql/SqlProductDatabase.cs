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
            throw new NotImplementedException();
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
                        Description = row["description"].ToString(),
                        Price = Convert.ToDecimal(row[3]),
                        IsDiscontinued = Convert.ToBoolean(row[4]),
                        
                    };
                };
            };
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        protected override void RemoveCore ( int id )
        {
            throw new NotImplementedException();
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected override Product UpdateCore ( Product existing, Product product )
        {
            throw new NotImplementedException();
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
