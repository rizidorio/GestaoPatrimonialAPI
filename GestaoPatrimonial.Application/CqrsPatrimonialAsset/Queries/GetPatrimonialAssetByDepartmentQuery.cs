using GestaoPatrimonial.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace GestaoPatrimonial.Application.CqrsPatrimonialAsset.Queries
{
    public class GetPatrimonialAssetByDepartmentQuery : IRequest<IEnumerable<PatrimonialAsset>>
    {
        public int DepartmentId { get; set; }

        public GetPatrimonialAssetByDepartmentQuery(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
