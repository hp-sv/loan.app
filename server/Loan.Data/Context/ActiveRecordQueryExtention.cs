

using Loan.Entity;
using Loan.Interface.Constants;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection;

namespace Loan.Data.Context
{
    public static class ActiveRecordQueryExtension
    {
        public static void AddActiveRecordOnlyQueryFilter(
            this IMutableEntityType entityData)
        {
            var methodToCall = typeof(ActiveRecordQueryExtension)
                .GetMethod(nameof(GetDeletedFilter),
                    BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall.Invoke(null, new object[] { });
            entityData.SetQueryFilter((LambdaExpression)filter);
            entityData.AddIndex(entityData.
                 FindProperty(nameof(ILoanEntity.RecordStatusId)));
        }

        private static LambdaExpression GetDeletedFilter<TEntity>()
            where TEntity : class, ILoanEntity
        {
            Expression<Func<TEntity, bool>> filter = r => r.RecordStatusId == LookupIds.RecordStatus.Active;
            return filter;
        }
    }
}
