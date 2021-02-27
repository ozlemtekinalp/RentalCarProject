using Business.Abstract;
using Business.Constans;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerdal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerdal = customerDal;
        }
        public IResult Add(Customer customer)
        {
            _customerdal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {

            _customerdal.Delete(customer);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerdal.GetAll());
        }

        public IDataResult<Customer> GetById(int id)
        {
            return new SuccessDataResult<Customer>(_customerdal.Get(c => c.Id == id));
        }

        public IResult Update(Customer customer)
        {

            _customerdal.Update(customer);
            return new SuccessResult(Messages.ColorUpdated);
        }

    }
}
