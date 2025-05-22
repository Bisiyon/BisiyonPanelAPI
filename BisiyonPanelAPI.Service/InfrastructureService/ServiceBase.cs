using BisiyonPanelAPI.Common;
using BisiyonPanelAPI.Domain;
using BisiyonPanelAPI.Interface;

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

        public async Task<Result<T>> GetAsync(int id)
        {
            return await _unitOfWork.Repository<T>().GetAsync(id);
        }

        public async Task<Result<T>> Insert(T entity)
        {
            return await _unitOfWork.Repository<T>().Insert(entity);
        }

        public async Task<Result<bool>> Update(T entity)
        {
            return await _unitOfWork.Repository<T>().Update(entity);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            return await _unitOfWork.Repository<T>().Delete(id);
        }
    }
}