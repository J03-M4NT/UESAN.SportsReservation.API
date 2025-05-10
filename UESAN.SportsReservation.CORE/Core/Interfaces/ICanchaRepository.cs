using UESAN.SportsReservation.CORE.Core.Entities;

namespace UESAN.SportsReservation.CORE.Core.Interfaces
{
    public interface ICanchaRepository
    {
        Task<int> CreateCancha(Canchas cancha);
        Task DeleteCanchaAsync(int id);
        Task DeleteCanchaSoft(int id);
        IEnumerable<Canchas> GetAllCanchas();
        Task<IEnumerable<Canchas>> GetAllCanchasAsync();
        Task<Canchas> GetCanchaByIdAsync(int id);
        Task<bool> UpdateCanchaAsync(Canchas cancha);
    }

    // La interfaz ICanchaRepository define los métodos que se implementarán en la clase CanchasRepository.
    // Aquella que podría utilizar una capa siguiente, como la capa de servicios, para interactuar con la base de datos.
    // La interfaz muestra los títulos de los métodos que se implementarán en el repositorio.

    // Para aplicaciones externas, es totalmente independiente de cómo se ejecute, pero permitirá realizar las operaciones necesarias.
}
