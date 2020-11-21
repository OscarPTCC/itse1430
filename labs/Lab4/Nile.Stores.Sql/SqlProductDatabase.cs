/*
 * ITSE 1430
 * Oscar Peinado-Rojo
 */
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Collections.Generic;

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
            throw new NotImplementedException();
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

        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
        private readonly string _connectionString;
    }
}
