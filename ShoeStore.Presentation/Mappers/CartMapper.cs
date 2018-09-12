using ShoeStore.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Presentation.Mappers
{
    public class CartMapper
    {
        public ICollection<ItemVM> GetCartItem(HttpSessionStateBase session)
        {
            InitializeCartItem(session);
            return (ICollection<ItemVM>) session["cart"];
        }

        public void AddItemToCart(ItemVM ci, HttpSessionStateBase session)
        {
            ICollection<ItemVM> items = GetCartItem(session);
            items.Add(ci);
            SetCart(items, session);
        }

        private void SetCart(ICollection<ItemVM> citems, HttpSessionStateBase session)
        {
            session["cart"] = citems;
        }

        private void InitializeCartItem(HttpSessionStateBase session)
        {
            if(session["cart"] == null)
            {
                session["cart"] = new List<ItemVM>();
            }
        }

        public void ResetCart(HttpSessionStateBase session)
        {
            session["cart"] = new List<ItemVM>();
        }
    }
}