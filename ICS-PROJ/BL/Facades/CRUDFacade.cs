using System;
using System.Collections.Generic;
using System.Text;
using DB.Entities;
using BL.Models;

namespace BL.Facades
{
    public class CRUDFacade<TEntity, TListModel, TDetailModel>
        where TEntity : class, IEntity<Guid>
        where TListModel : IModel<Guid>
        where TDetailModel : class, IModel<Guid>
    {

    }
}