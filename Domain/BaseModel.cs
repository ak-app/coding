using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Domain
{
    public abstract class BaseModel
    {
        [Range(
            0,
            int.MaxValue, 
            ErrorMessageResourceType = typeof(Resource.ErrorResource),
            ErrorMessageResourceName = nameof(RangeAttribute))]
        public int Id { get; set; }
    }
}
