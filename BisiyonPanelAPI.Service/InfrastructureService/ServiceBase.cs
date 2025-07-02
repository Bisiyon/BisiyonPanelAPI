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

        public async Task<T> Insert(T entity)
        {
            return await _unitOfWork.Repository<T>().Insert(entity);
        }

        public async Task<bool> Update(T newEntity)
        {
            return await _unitOfWork.Repository<T>().Update(newEntity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _unitOfWork.Repository<T>().Delete(id);
        }

        public async Task<PagedResult<List<TDto>>> GetAllAsync<TDto>(DataFilterModelView model)
        {
            return await _unitOfWork.Repository<T>().GetAllAsync<TDto>(model);
        }
        public async Task<PagedResult<List<T>>> GetAllAsync(DataFilterModelView model)
        {
            return await _unitOfWork.Repository<T>().GetAllAsync(model);
        }

        public async Task<Result<List<TDto>>> GetAllAsync<TDto>(Expression<Func<T, bool>>? predicate, Func<IQueryable<T>, IQueryable<T>> includeFunc = null)
        {
            return await _unitOfWork.Repository<T>().GetAllAsync<TDto>(predicate, includeFunc);
        }
        public async Task<Result<List<TDto>>> GetAllAsync<TDto>()
        {
            return await _unitOfWork.Repository<T>().GetAllAsync<TDto>();
        }

        public async Task<Result<TDto?>> GetByIdAsync<TDto>(int id)
        {
            return await _unitOfWork.Repository<T>().GetByIdAsync<TDto>(id);

        }
        public async Task<T> Insert<TDto>(TDto entity)
        {
            return await _unitOfWork.Repository<T>().Insert<TDto>(entity);
        }
        public async Task<List<T>> BulkInsert<TDto>(List<TDto> entity)
        {
            return await _unitOfWork.Repository<T>().BulkInsert<TDto>(entity);
        }

        public async Task<bool> Update<TDto>(TDto newEntity)
        {
            return await _unitOfWork.Repository<T>().Update<TDto>(newEntity);
        }


    }
}