﻿using Domain.Interfaces;
using Domain.Models;

namespace BusinessLogic.Services
{
    public class OrdersService : IOrdersService
    {
        private IRepositoryWrapper _repositoryWrapper;

        public OrdersService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _repositoryWrapper.Order.FindAll();
        }

        public async Task<Order> GetById(int id)
        {
            var order = await _repositoryWrapper.Order
                .FindByCondition(x => x.OrderId == id);
            return order.First();
        }

        public async Task Create(Order model)
        {
            await _repositoryWrapper.Order.Create(model);
            _repositoryWrapper.Save();
        }

        public async Task Update(Order model)
        {
            _repositoryWrapper.Order.Update(model);
            _repositoryWrapper.Save();
        }

        public async Task Delete(int id)
        {
            var order = await _repositoryWrapper.Order
                .FindByCondition(x => x.OrderId == id);

            _repositoryWrapper.Order.Delete(order.First());
            _repositoryWrapper.Save();
        }
    }
}