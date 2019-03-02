using System;
namespace MNK.HRM.DTO
{
    public interface IEmployee
    {
        bool IsActive { get; set; }

        DateTime UpdateDate { get; set; }

        string UpdateUser { get; set; }

    }
}
