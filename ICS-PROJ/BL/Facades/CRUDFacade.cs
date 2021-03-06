using AutoMapper;
using BL.Models;
using DB.Entities;
using DB.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BL.Facades
{
    public abstract class CRUDFacade<TEntity, TListModel, TDetailModel>
        where TEntity : class, IEntity<Guid>
        where TListModel : IModel<Guid>
        where TDetailModel : class, IModel<Guid>
    {
        private readonly IMapper? _mapper;
        private readonly IUnitOfWorkFactory? _unitOfWorkFactory;

        protected CRUDFacade(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
            _mapper = mapper;
        }

        public async Task DeleteAsync(TDetailModel model) => await this.DeleteAsync(model);

        public async Task DeleteAsync(Guid ID)
        {
            await using var uow = _unitOfWorkFactory.Create();
            uow.GetRepository<TEntity>().Delete(ID);
            await uow.CommitAsync().ConfigureAwait(false);
        }

        public async Task<TDetailModel?> GetAsync(Guid ID)
        {
            await using var uow = _unitOfWorkFactory.Create();
            var query = uow.GetRepository<TEntity>().Get().Where(e => e.ID == ID);
            return await _mapper.ProjectTo<TDetailModel>(query).SingleOrDefaultAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<TListModel>> GetAsync()
        {
            await using var uow = _unitOfWorkFactory.Create();
            var query = uow.GetRepository<TEntity>().Get();
            return await _mapper.ProjectTo<TListModel>(query).ToArrayAsync().ConfigureAwait(false);
        }

        public async Task<TDetailModel> SaveAsync(TDetailModel model)
        {
            await using var uow = _unitOfWorkFactory.Create();

            var entity = await uow.GetRepository<TEntity>().InsertOrUpdateAsync(model, _mapper).ConfigureAwait(false);
            await uow.CommitAsync();

            return (await GetAsync(entity.ID).ConfigureAwait(false))!;
        }
    }
}