/*
 * ITSE 1430
 * Oscar Peinado-Rojo
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            ObjectValidator.ValidateFullObject(product);

            foreach (var result in GetAll())
            {
                if (String.Compare(result.Name, product.Name, true) == 0)
                {
                    if (result.Name == product.Name)
                        throw new InvalidOperationException("Product name must be unique");
                };
            };

            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than or equal to zero");

            return GetCore(id);
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            try
            {
                return GetAllCore();
            } catch (Exception e)
            {
                throw new InvalidOperationException("Get AllFailed", e);
            };
        }

        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than or equal to zero");

            RemoveCore(id);
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            ObjectValidator.TryValidateFullObject(product);
            foreach (var result in GetAll())
            {
                Product exist;
                if (String.Compare(result.Name, product.Name, true) == 0)
                {
                    exist = result;
                    if (exist != null && exist.Id != product.Id)
                        throw new InvalidOperationException("Product name must be unique");
                };
            };

            //Get existing product
            var existing = GetCore(product.Id);
            if (existing != null && existing.Id != product.Id)
                throw new InvalidOperationException("Product must be unique");

            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract Product GetCore ( int id );

        protected abstract IEnumerable<Product> GetAllCore ();

        protected abstract void RemoveCore ( int id );

        protected abstract Product UpdateCore ( Product existing, Product newItem );

        protected abstract Product AddCore ( Product product );
        #endregion
    }
}
