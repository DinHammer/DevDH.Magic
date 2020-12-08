using DevDH.Magic.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using dalDataObjects = DevDH.Magic.Abstractions.DataObjects;

namespace DevDH.Magic.DAL.RepositorySql
{
    /// <summary>
    /// 
    /// </summary>
    /// <see cref="DevDH.Magic.DAL.RepositorySql.Action.ActionSimple">
    public interface IActionSimple
    {
        /// <summary>
        /// Добавить одно данное в таблицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RequestResult<T>> mgcAsncAdd<T>(T data) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<T> mgcAdd<T>(T data) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Добавить набор данных в таблицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RequestResult> mgcAsncAddRange<T>(List<T> data) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcAddRange<T>(List<T> data) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Обновить одно данное в таблице
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RequestResult> mgcAsncUpdate<T>(T data) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcUpdate<T>(T data) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Обновить набор данных в таблице
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        Task<RequestResult> mgcAsncUpdateRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcUpdateRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId;



        /// <summary>
        /// Удалить одно значение
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<RequestResult> mgcAsncDelete<T>(T item) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcDelete<T>(T item) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// УДалить набор данных из таблицы
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        Task<RequestResult> mgcAsncDeleteRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcDeleteRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Удалить данное по Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RequestResult> mgcAsncDeleteById<T>(int id) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcDeleteById<T>(int id) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// УДалить данные по условию
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult> mgcAsncDeleteByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcDeleteByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Удалить всё нахрен)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<RequestResult> mgcAsncDeleteAll<T>() where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcDeleteAll<T>() where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить все данные
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<RequestResult<List<T>>> mgcAsncGetAll<T>() where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<List<T>> mgcGetAll<T>() where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить колличество данных в таблице
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<RequestResult<Tuple<int>>> mgcAsncGetCount<T>() where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<Tuple<int>> mgcGetCount<T>() where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить набор данных удоавлетворяющих запросу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult<List<T>>> mgcAsncGetByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<List<T>> mgcGetByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить первое данное удобвлетворящее значению
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult<T>> mgcAsncGetFirstByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<T> mgcGetFirstByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить одно данное удовлетворяющее запросу и проверить что оно существует
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult<Tuple<bool, T>>> mgcAsncGetFirstByQueryCheckValid<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<Tuple<bool, T>> mgcGetDataFirstByQueryCheckValid<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить данное по id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RequestResult<T>> mgcAsncGetById<T>(int id) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<T> mgcGetById<T>(int id) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить данное по id и проверить что оно существует
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RequestResult<Tuple<bool, T>>> mgcAsncGetByIdAndCheckValid<T>(int id) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<Tuple<bool, T>> mgcGetByIdAndCheckValid<T>(int id) where T : class, dalDataObjects.IBaseObjectId;
    }
}
