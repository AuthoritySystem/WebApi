using AuthoritySystem.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AuthoritySystem.IService.Base
{
    /// <summary>
    /// 泛型接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseService<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ValidateResult> AddAsync(TEntity entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<ValidateResult> UpdateAsync(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ValidateResult> DeleteAsync(Guid id);

        /// <summary>
        /// 获取单个实体（条件）
        /// </summary>
        /// <param name="predicate">条件表达式</param>
        /// <returns></returns>
        Task<TEntity> GetEntityAsync(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 根据条件获取集合数据
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
