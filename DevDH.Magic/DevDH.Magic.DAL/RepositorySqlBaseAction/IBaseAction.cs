using System;
using System.Collections.Generic;
using System.Text;
using dalDataObjects = DevDH.Magic.Abstractions.DataObjects;
//using coreDataObjects = DevDH.Magic.Abstractions.DataObjects;
using System.Threading.Tasks;
using DevDH.Magic.Abstractions;
using System.Linq.Expressions;

namespace DevDH.Magic.DAL.RepositorySqlBaseAction
{
    public interface IBaseAction<T> where T : class, dalDataObjects.IBaseObjectId
    {
        Task<RequestResult<T>> mgcAsncAdd(T data);
        RequestResult<T> mgcSncAdd(T data);

        Task<RequestResult> mgcAsncAddRange(List<T> data);
        RequestResult mgcSncAddRange(List<T> data);

        Task<RequestResult> mgcAsncUpdate(T data);
        RequestResult mgcSncUpdate(T data);

        Task<RequestResult> mgcAsncUpdateRange(List<T> data);
        RequestResult mgcSncUpdateRange(List<T> data);

        Task<RequestResult> mgcAsncDelete(T data);
        RequestResult mgcSncDelete(T data);

        Task<RequestResult> mgcAsncDeleteRange(List<T> data);
        RequestResult mgcSncDeleteRange(List<T> data);

        Task<RequestResult> mgcAsncDeleteById(int id);
        RequestResult mgcSncDeleteById(int id);

        Task<RequestResult> mgcAsncDeleteByQuery(Expression<Func<T, bool>> predicate);
        RequestResult mgcSncDeleteByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult> mgcAsncDeleteAll();
        RequestResult mgcSncDeleteAll();

        Task<RequestResult<List<T>>> mgcAsncGetAll();
        RequestResult<List<T>> mgcSncGetAll();

        Task<RequestResult<Tuple<int>>> mgcAsncGetCount();
        RequestResult<Tuple<int>> mgcSncGetCount();

        Task<RequestResult<List<T>>> mgcAsncGetByQuery(Expression<Func<T, bool>> predicate);
        RequestResult<List<T>> mgcSncGetByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult<T>> mgcAsncGetFirstByQuery(Expression<Func<T, bool>> predicate);
        RequestResult<T> mgcSncGetFirstByQuery(Expression<Func<T, bool>> predicate);

        Task<RequestResult<Tuple<bool, T>>> mgcAsncGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate);
        RequestResult<Tuple<bool, T>> mgcSncGetFirstByQueryCheckValid(Expression<Func<T, bool>> predicate);

        Task<RequestResult<T>> mgcAsncGetById(int id);
        RequestResult<T> mgcSncGetById(int id);

        Task<RequestResult<Tuple<bool, T>>> mgcAsncGetByIdCheckValid(int id);
        RequestResult<Tuple<bool, T>> mgcSncGetByIdCheckValid(int id);
    }
}
