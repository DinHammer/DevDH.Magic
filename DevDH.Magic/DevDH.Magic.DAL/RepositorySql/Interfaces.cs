using DevDH.Magic.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using dalDataObjects = DevDH.Magic.Abstractions.DataObjects;

namespace DevDH.Magic.DAL.RepositorySql
{
    #region IActionSimple
    /// <see cref="DevDH.Magic.DAL.RepositorySql.Action.ActionSimple">
    public interface IActionSimple
    {
        /// <summary>
        /// Добавить одно данное в таблицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RequestResult<T>> mgcAddAsnc<T>(T data) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<T> mgcAdd<T>(T data) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Добавить набор данных в таблицу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RequestResult> mgcAddRangeAsnc<T>(List<T> data) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcAddRange<T>(List<T> data) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Обновить одно данное в таблице
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<RequestResult> mgcUpdateAsnc<T>(T data) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcUpdate<T>(T data) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Обновить набор данных в таблице
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        Task<RequestResult> mgcUpdateRangeAsnc<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcUpdateRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId;



        /// <summary>
        /// Удалить одно значение
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<RequestResult> mgcDeleteAsnc<T>(T item) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcDelete<T>(T item) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// УДалить набор данных из таблицы
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <returns></returns>
        Task<RequestResult> mgcDeleteRangeAsnc<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcDeleteRange<T>(List<T> items) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Удалить данное по Id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RequestResult> mgcDeleteByIdAsnc<T>(int id) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcDeleteById<T>(int id) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// УДалить данные по условию
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult> mgcDeleteByQueryAsnc<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcDeleteByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Удалить всё нахрен)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<RequestResult> mgcDeleteAllAsnc<T>() where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcDeleteAll<T>() where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить все данные
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<RequestResult<List<T>>> mgcGetAllAsnc<T>() where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<List<T>> mgcGetAll<T>() where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить колличество данных в таблице
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<RequestResult<dalDataObjects.MgcInt>> mgcGetCountAsnc<T>() where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<dalDataObjects.MgcInt> mgcGetCount<T>() where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить набор данных удоавлетворяющих запросу
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult<List<T>>> mgcGetByQueryAsnc<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<List<T>> mgcGetByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить первое данное удобвлетворящее значению
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult<T>> mgcGetFirstByQueryAsnc<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<T> mgcGetFirstByQuery<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить одно данное удовлетворяющее запросу и проверить что оно существует
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<RequestResult<dalDataObjects.MgcBoolData<T>>> mgcGetFirstByQueryCheckValidAsnc<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<dalDataObjects.MgcBoolData<T>> mgcGetFirstByQueryCheckValid<T>(Expression<Func<T, bool>> predicate) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить данное по id
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RequestResult<T>> mgcGetByIdAsnc<T>(int id) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<T> mgcGetById<T>(int id) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Получить данное по id и проверить что оно существует
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<RequestResult<dalDataObjects.MgcBoolData<T>>> mgcGetByIdAndCheckValidAsnc<T>(int id) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult<dalDataObjects.MgcBoolData<T>> mgcGetByIdAndCheckValid<T>(int id) where T : class, dalDataObjects.IBaseObjectId;
    }
    #endregion

    #region IActionSql
    public interface IActionSql
    {
        Task<DbContext> mgcGetDbContextAsync();

        /// <summary>
        /// Получить контекст базы данных для работы
        /// </summary>
        /// <returns></returns>
        DbContext mgcGetDbContext();

        /// <summary>
        /// Удалить все данные в созданных таблицах
        /// </summary>
        /// <returns></returns>
        RequestResult mgcDeleteDataAllInDatabase();

        /// <summary>
        /// Вставить одно данное по id или обновить если текущий id уже занят
        /// </summary>
        /// <typeparam name="T">тип данных</typeparam>
        /// <param name="item">имя данного</param>
        /// <param name="str_table_name">имя таблицы в которую необходимо вставить данные (для MsSql стоит добавлять dbo. префикс перед именем)</param>
        /// <returns></returns>
        Task<RequestResult> mgcInsertOrUpdateAsnc<T>(T item, string str_table_name) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcInsertOrUpdate<T>(T item, string str_table_name) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Вставить набор данных по id или обновить если id уже занят
        /// </summary>
        /// <typeparam name="T">тип данных</typeparam>
        /// <param name="items">имя данных</param>
        /// <param name="str_table_name">имя таблицы в которую необходимо вставить данные (для MsSql стоит добавлять dbo. префикс перед именем)</param>
        /// <returns></returns>
        Task<RequestResult> mgcInsertOrUpdateRangeAsnc<T>(List<T> items, string str_table_name) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcInsertOrUpdateRange<T>(List<T> items, string str_table_name) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Вставить набор данных по id
        /// </summary>
        /// <typeparam name="T">тип данных</typeparam>
        /// <param name="items">имя данных</param>        
        /// <returns></returns>
        Task<RequestResult> mgcInsertRangeAsnc<T>(List<T> items, string str_table_name) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcInsertRange<T>(List<T> items, string str_table_name) where T : class, dalDataObjects.IBaseObjectId;

        /// <summary>
        /// Вставить одно данное по id
        /// </summary>
        /// <typeparam name="T">тип данного</typeparam>
        /// <param name="item">имя данного</param>        
        /// <returns></returns>
        Task<RequestResult> mgcInsertAsnc<T>(T item, string str_table_name) where T : class, dalDataObjects.IBaseObjectId;
        RequestResult mgcInsert<T>(T item, string str_table_name) where T : class, dalDataObjects.IBaseObjectId;
    }
    #endregion
}
