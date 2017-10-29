using Moq;
using System.Data.Entity;
using System.Linq;

namespace USP.ESI.SUEP.Tests.Util
{
    public class MockUtil<T> where T : class
    {
        /// <summary>
        /// Transforma os dados selecionáveis em dados mockados
        /// </summary>
        /// <param name="_par_objQueryableData">Dados selecionáveis que serão usados como conjunto de entidades</param>
        /// <returns>Dados mockados</returns>
        public static Mock<DbSet<T>> GetMockSet(IQueryable<T> _par_objQueryableData)
        {
            var _objMockSet = new Mock<DbSet<T>>();
            _objMockSet.As<IQueryable<T>>()
                .Setup(m => m.Provider).Returns(_par_objQueryableData.Provider);
            _objMockSet.As<IQueryable<T>>()
                .Setup(m => m.Expression).Returns(_par_objQueryableData.Expression);
            _objMockSet.As<IQueryable<T>>()
                .Setup(m => m.ElementType).Returns(_par_objQueryableData.ElementType);
            _objMockSet.As<IQueryable<T>>()
                .Setup(m => m.GetEnumerator()).Returns(_par_objQueryableData.GetEnumerator());
            return _objMockSet;
        }
    }
}
