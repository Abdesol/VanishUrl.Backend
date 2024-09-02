using System.ComponentModel.DataAnnotations;

namespace VanishUrl.Api.Dtos;

public record SetDataRequest(
    [Required] [MinLength(3)] [MaxLength(5000)] string Data);