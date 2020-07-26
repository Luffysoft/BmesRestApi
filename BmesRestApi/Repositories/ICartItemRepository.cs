﻿using System.Collections.Generic;
using BmesRestApi.Models.Carts;

namespace BmesRestApi.Repositories
{
    public interface ICartItemRepository
    {
        CartItem FindCartItemById(long id);
        IEnumerable<CartItem> FindCartItemsByCartId(long cartId);
        void SaveCartItem(CartItem cartItem);
        void UpdateCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);
    }
}
