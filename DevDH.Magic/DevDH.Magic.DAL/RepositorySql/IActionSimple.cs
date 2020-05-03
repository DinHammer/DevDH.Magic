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
        Task<RequestResult<T>> AddDataAsync<T>(T data) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult<T> AddData<T>(T data) where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Добавить набор данных в таблицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RequestResult> AddDataRangeAsync<T>(List<T> data) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult AddDataRange<T>(List<T> data) where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Обновить одно данное в таблице
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RequestResult> UpdateDataAsync<T>(T data) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult UpdateData<T>(T data) where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Обновить набор данных в таблице
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        Task<RequestResult> UpdateDataRangeAsync<T>(List<T> items) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult UpdateDataRange<T>(List<T> items) where T : class, dalDataObjects.IObjectSqlBase;



        /// <summary>
        /// Удалить одно значение
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<RequestResult> DeleteAsync<T>(T item) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult Delete<T>(T item) where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// УДалить набор данных из таблицы
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        Task<RequestResult> DeleteRangeAsync<T>(List<T> items) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult DeleteRange<T>(List<T> items) where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Удалить данное по Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RequestResult> DeleteByIdAsync<T>(int id) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult DeleteById<T>(int id) where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// УДалить данные по условию
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult> DeleteByQueryAsync<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult DeleteByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Удалить всё нахрен)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<RequestResult> DeleteAllAsync<T>() where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult DeleteAll<T>() where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Получить все данные
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<RequestResult<List<T>>> GetDataAllAsunc<T>() where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult<List<T>> GetDataAll<T>() where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Получить колличество данных в таблице
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<RequestResult<Tuple<int>>> GetCountAsync<T>() where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult<Tuple<int>> GetCount<T>() where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Получить набор данных удоавлетворяющих запросу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult<List<T>>> GetDataByQueryAsync<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult<List<T>> GetDataByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Получить первое данное удобвлетворящее значению
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult<T>> GetDataFirstByQueryAsync<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult<T> GetDataFirstByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Получить одно данное удовлетворяющее запросу и проверить что оно существует
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult<Tuple<bool, T>>> GetDataFirstByQueryCheckValidAsync<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult<Tuple<bool, T>> GetDataFirstByQueryCheckValid<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Получить данное по id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RequestResult<T>> GetDataByIdAsunc<T>(int id) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult<T> GetDataById<T>(int id) where T : class, dalDataObjects.IObjectSqlBase;

        /// <summary>
        /// Получить данное по id и проверить что оно существует
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RequestResult<Tuple<bool, T>>> GetDataByIdCheckValidAsunc<T>(int id) where T : class, dalDataObjects.IObjectSqlBase;
        RequestResult<Tuple<bool, T>> GetDataByIdCheckValid<T>(int id) where T : class, dalDataObjects.IObjectSqlBase;
    }
}
