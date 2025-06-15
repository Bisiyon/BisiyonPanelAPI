using System.Linq.Expressions;
using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Interface;
using Mapster;

namespace BisiyonPanelAPI.Service
{
    public class ServiceBase<T> : IServiceBase<T> where T : class, IEntity
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServiceBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<List<T>>> GetAllAsync()
        {
            return await _unitOfWork.Repository<T>().GetAllAsync();
        }
        public async Task<Result<List<T>>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _unitOfWork.Repository<T>().GetAllAsync(predicate);
        }
        public async Task<Result<T?>> GetByIdAsync(int id)
        {
            return await _unitOfWork.Repository<T>().GetByIdAsync(id);
        }

        public async Task<Result<T>> Insert(T entity)
        {
            return await _unitOfWork.Repository<T>().Insert(entity);
        }

        public async Task<Result<bool>> Update(T oldEntity, T newEntity)
        {
            return await _unitOfWork.Repository<T>().Update(oldEntity, newEntity);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            return await _unitOfWork.Repository<T>().Delete(id);
        }

        public async Task<Result<List<TDto>>> GetAllAsync<TDto>(DataFilterModelView model)
        {
            return await _unitOfWork.Repository<T>().GetAllAsync<TDto>(model);
        }
        public async Task<Result<List<T>>> GetAllAsync(DataFilterModelView model)
        {
            return await _unitOfWork.Repository<T>().GetAllAsync(model);
        }
    }
}