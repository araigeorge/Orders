using Orders.Backend.UnitsOfWork.Interfaces;
using Orders.Shared.Entities;
using Orders.Shared.Enums;

namespace Orders.Backend.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
       // private readonly IApiService _apiService;
        private readonly IUsersUnitOfWork _usersUnitOfWork;
        public SeedDb(DataContext context, IUsersUnitOfWork usersUnitOfWork)
        {
            _context = context;
            //_apiService = apiService;
            _usersUnitOfWork = usersUnitOfWork;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckCategoriesAsync();
            await CheckRolesAsync(); 
            await CheckUserAsync("1010", "Juan", "Zuluaga", "zulu@yopmail.com", "322 311 4620", "Calle Luna Calle Sol", UserType.Admin);
        }
        private async Task CheckRolesAsync() 
        { 
            await _usersUnitOfWork.CheckRoleAsync(UserType.Admin.ToString()); 
            await _usersUnitOfWork.CheckRoleAsync(UserType.User.ToString());
        }
        private async Task<User> CheckUserAsync(string document, string firstName, string lastName, string email, string phone, string address, UserType userType)
        {
            var user = await _usersUnitOfWork.GetUserAsync(email); 
            if (user == null)
            {
                user = new User 
                {
                    FirstName = firstName, 
                    LastName = lastName,
                    Email = email, 
                    UserName = email, 
                    PhoneNumber = phone, 
                    Address = address, 
                    Document = document, 
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType, 
                };
                await _usersUnitOfWork.AddUserAsync(user, "123456"); 
                await _usersUnitOfWork.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = 
                    [
                       
                       new State()
                       {
                           Name = "Antioquia",
                           Cities =
                           [
                               new() { Name = "Medellín" },
                               new() { Name = "Itagüí" },
                               new() { Name = "Envigado" },
                               new() { Name = "Bello" },
                               new() { Name = "Rionegro" },
                           ]
                       },
                       new State()
                       {
                           Name = "Bogotá",
                           Cities =
                           [
                               new() { Name = "Usaquen" },
                               new() { Name = "Champinero" },
                               new() { Name = "Santa fe" },
                               new() { Name = "Useme" },
                               new() { Name = "Bosa" },
                           ]
                       },
                    ]
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States =
                    [
                        new State()
                        {
                            Name = "Florida",
                            Cities =
                            [
                                new() { Name = "Orlando" },
                                new() { Name = "Miami" },
                                new() { Name = "Tampa" },
                                new() { Name = "Fort Lauderdale" },
                                new() { Name = "Key West" },
                            ]
                        },
                        new State()
                        {
                            Name = "Texas",
                            Cities =
                            [
                                new() { Name = "Houston" },
                                new() { Name = "San Antonio" },
                                new() { Name = "Dallas" },
                                new() { Name = "Austin" },
                                new() { Name = "El Paso" },
                            ]
                        },
                    ]
                });
                _context.Countries.Add(new Country
                {
                    Name = "Republica Dominicana",
                    States =
                   [
                         new State()
                        {
                            Name = "Distrito Nacional",
                            Cities =
                            [
                                new() { Name = "Distrito Nacional" },
                            ]
                        },
                       new State()
                        {
                            Name = "Santo Domingo",
                            Cities =
                            [
                                new() { Name = "Santo Domingo Este" },
                                new() { Name = "Santo Domingo Norte" },
                                new() { Name = "Santo Domingo Oeste" },
                                new() { Name = "Boca Chica" },
                                new() { Name = "Los Alcarrizos" },
                                new() { Name = "Pedro Brand" },
                                new() { Name = "San Antonio de Guerra" },
                            ]
                        },

                        new State()
                        {
                            Name = "Santiago",
                            Cities =
                            [
                                new() { Name = "Santiago" },
                                new() { Name = "Bisonó" },
                                new() { Name = "Jánico" },
                                new() { Name = "Licey Al Medio" },
                                new() { Name = "Puñal" },
                                new() { Name = "Sabana Iglesia" },
                                new() { Name = "San Jose de las Matas" },
                                new() { Name = "Tamboril" },
                                new() { Name = "Villa Gonzalez" },
                            ]
                        },
                        new State()
                        {
                            Name = "Azua",
                            Cities =
                            [
                                new() { Name = "Azua de Compostela" },
                                new() { Name = "Estebania" },
                                new() { Name = "Guayabal" },
                                new() { Name = "Las Charcas" },
                                new() { Name = "Las yayas de Viajama" },
                                new() { Name = "Padre de las Casas" },
                                new() { Name = "Peralta" },
                                new() { Name = "Pueblo Viejo" },
                                new() { Name = "Sabana Yegua" },
                                new() { Name = "Tábara Arriba" },
                            ]
                        },
                        new State()
                        {
                            Name = "Bahoruco",
                            Cities =
                            [
                                new() { Name = "Neiba" },
                                new() { Name = "Cabral" },
                                new() { Name = "El Peñon" },
                                new() { Name = "Enrriquillo" },
                                new() { Name = "Fundación" },
                                new() { Name = "Jaquimeyes" },
                                new() { Name = "La Cienaga" },
                                new() { Name = "Las Salinas" },
                                new() { Name = "Paraiso" },
                                new() { Name = "Polo" },
                                new() { Name = "Vicente Noble" },
                            ]
                        },
                        new State()
                        {
                            Name = "Dajabon",
                            Cities =
                            [
                                new() { Name = "Dajabón" },
                                new() { Name = "El Pino" },
                                new() { Name = "Loma de Cabrera" },
                                new() { Name = "Partido" },
                                new() { Name = "Restauración" },
                            ]
                        },
                        new State()
                        {
                            Name = "Duarte",
                            Cities =
                            [
                                new() { Name = "San Francisco de Macorís" },
                                new() { Name = "Arenoso" },
                                new() { Name = "Castillo" },
                                new() { Name = "Eugenio María de Hostos" },
                                new() { Name = "Las Guáranas" },
                                new() { Name = "Pimentel" },
                                new() { Name = "Villa Riva" },
                            ]
                        },
                        new State()
                        {
                            Name = "El Seibo",
                            Cities =
                            [
                                new() { Name = "El Seibo" },
                                new() { Name = "Miches" },
                            ]
                        },
                        new State()
                        {
                            Name = "Elías Piña",
                            Cities =
                            [
                                new() { Name = "Comendador" },
                                new() { Name = "Bánica" },
                                new() { Name = "El Llano" },
                                new() { Name = "Hondo Valle" },
                                new() { Name = "Juan Santiago" },
                                new() { Name = "Pedro Santana" },
                            ]
                        },
                        new State()
                        {
                            Name = "Espaillat",
                            Cities =
                            [
                                new() { Name = "Moca" },
                                new() { Name = "Cayetano Germosén" },
                                new() { Name = "Gaspar Hernández" },
                                new() { Name = "Jamao al Norte" },
                            ]
                        },
                        new State()
                        {
                            Name = "Hato Mayor",
                            Cities =
                            [
                                new() { Name = "Hato Mayor del Rey" },
                                new() { Name = "El Valle" },
                                new() { Name = "Sabana de la Mar" },
                            ]
                        },
                        new State()
                        {
                            Name = "Hermanas Mirabal",
                            Cities =
                            [
                                new() { Name = "Salcedo" },
                                new() { Name = "Tenares" },
                                new() { Name = "Villa Tapia" },
                            ]
                        },
                        new State()
                        {
                            Name = "Independencia",
                            Cities =
                            [
                                new() { Name = "Jimaní" },
                                new() { Name = "Cristóbal" },
                                new() { Name = "Duvergé" },
                                new() { Name = "La Descubierta" },
                                new() { Name = "Mella" },
                                new() { Name = "Postrer Río" },
                            ]
                        },
                        new State()
                        {
                            Name = "La Altagracia",
                            Cities =
                            [
                                new() { Name = "Higüey" },
                                new() { Name = "San Rafael del Yuma" },
                            ]
                        },
                        new State()
                        {
                            Name = "La Romana",
                            Cities =
                            [
                                new() { Name = "La Romana" },
                                new() { Name = "Guaymate" },
                                new() { Name = "Villa Hermosa" },
                            ]
                        },
                        new State()
                        {
                            Name = "La Vega",
                            Cities =
                            [
                                new() { Name = "La Concepción de La Vega" },
                                new() { Name = "Constanza" },
                                new() { Name = "Jarabacoa" },
                                new() { Name = "Jima Abajo" },
                            ]
                        },
                        new State()
                        {
                            Name = "María Trinidad Sánchez",
                            Cities =
                            [
                                new() { Name = "Nagua" },
                                new() { Name = "Cabrera" },
                                new() { Name = "El Factor" },
                                new() { Name = "Río San Juan" },
                            ]
                        },
                        new State()
                        {
                            Name = "Monseñor Nouel",
                            Cities =
                            [
                                new() { Name = "Bonao" },
                                new() { Name = "Maimón" },
                                new() { Name = "Piedra Blanca" },
                            ]
                        },
                        new State()
                        {
                            Name = "Montecristi",
                            Cities =
                            [
                                new() { Name = "Montecristi" },
                                new() { Name = "Castañuela" },
                                new() { Name = "Guayubín" },
                                new() { Name = "Las Matas de Santa Cruz" },
                                new() { Name = "Pepillo Salcedo" },
                                new() { Name = "Villa Vásquez" },
                            ]
                        },
                        new State()
                        {
                            Name = "Monte Plata",
                            Cities =
                            [
                                new() { Name = "Monte Plata" },
                                new() { Name = "Bayaguana" },
                                new() { Name = "Peralvillo" },
                                new() { Name = "Sabana Grande de Boyá" },
                                new() { Name = "Yamasá" },
                            ]
                        },
                        new State()
                        {
                            Name = "Pedernales",
                            Cities =
                            [
                                new() { Name = "Pedernales" },
                                new() { Name = "Oviedo" },
                            ]
                        },
                        new State()
                        {
                            Name = "Peravia",
                            Cities =
                            [
                                new() { Name = "Baní" },
                                new() { Name = "Nizao" },
                            ]
                        },
                        new State()
                        {
                            Name = "Puerto Plata",
                            Cities =
                            [
                                new() { Name = "Puerto Plata" },
                                new() { Name = "Altamira" },
                                new() { Name = "Guananico" },
                                new() { Name = "Imbert" },
                                new() { Name = "Los Hidalgos" },
                                new() { Name = "Luperón" },
                                new() { Name = "Sosúa" },
                                new() { Name = "Villa Isabela" },
                                new() { Name = "Villa Montellano" },
                            ]
                        },
                        new State()
                        {
                            Name = "Samaná",
                            Cities =
                            [
                                new() { Name = "Samaná" },
                                new() { Name = "Las Terrenas" },
                                new() { Name = "Sánchez" },
                            ]
                        },
                        new State()
                        {
                            Name = "San Cristóbal",
                            Cities =
                            [
                                new() { Name = "San Cristóbal" },
                                new() { Name = "Bajos de Haina" },
                                new() { Name = "Cambita Garabito" },
                                new() { Name = "Los Cacaos" },
                                new() { Name = "Sabana Grande de Palenque" },
                                new() { Name = "San Gregorio de Nigua" },
                                new() { Name = "Villa Altagracia" },
                                new() { Name = "Yaguate" },
                            ]
                        },
                        new State()
                        {
                            Name = "San José de Ocoa",
                            Cities =
                            [
                                new() { Name = "San José de Ocoa" },
                                new() { Name = "Rancho Arriba" },
                                new() { Name = "Sabana Larga" },
                            ]
                        },
                        new State()
                        {
                            Name = "San Juan",
                            Cities =
                            [
                                new() { Name = "San Juan de la Maguana" },
                                new() { Name = "Bohechío" },
                                new() { Name = "El Cercado" },
                                new() { Name = "Juan de Herrera" },
                                new() { Name = "Las Matas de Farfán" },
                                new() { Name = "Vallejuelo" },
                            ]
                        },
                        new State()
                        {
                            Name = "San Pedro de Macorís",
                            Cities =
                            [
                                new() { Name = "San Pedro de Macorís" },
                                new() { Name = "Consuelo" },
                                new() { Name = "Guayacanes" },
                                new() { Name = "Quisqueya" },
                                new() { Name = "Ramón Santana" },
                                new() { Name = "San José de Los Llanos" },
                            ]
                        },
                        new State()
                        {
                            Name = "Sánchez Ramírez",
                            Cities =
                            [
                                new() { Name = "Cotuí" },
                                new() { Name = "Cevicos" },
                                new() { Name = "Fantino" },
                                new() { Name = "La Mata" },
                            ]
                        },

                        new State()
                        {
                            Name = "Santiago Rodríguez",
                            Cities =
                            [
                                new() { Name = "San Ignacio de Sabaneta" },
                                new() { Name = "Los Almácigos" },
                                new() { Name = "Monción" },
                            ]
                        },
                        new State()
                        {
                            Name = "Valverde",
                            Cities =
                            [
                                new() { Name = "Mao" },
                                new() { Name = "Esperanza" },
                                new() { Name = "Laguna Salada" },
                            ]
                        },
                    ]
                });
            }
        }


        private async Task CheckCategoriesAsync()
        {
            if (!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Apple" });
                _context.Categories.Add(new Category { Name = "Autos" });
                _context.Categories.Add(new Category { Name = "Belleza" });
                _context.Categories.Add(new Category { Name = "Comida" });
                _context.Categories.Add(new Category { Name = "Cosmeticos" });
                _context.Categories.Add(new Category { Name = "Deportes" });
                _context.Categories.Add(new Category { Name = "Erótica" });
                _context.Categories.Add(new Category { Name = "Ferreteria" });
                _context.Categories.Add(new Category { Name = "Gamer" });
                _context.Categories.Add(new Category { Name = "Hogar" });
                _context.Categories.Add(new Category { Name = "Jardín" });
                _context.Categories.Add(new Category { Name = "Juguetes" });
                _context.Categories.Add(new Category { Name = "Lenceria" });
                _context.Categories.Add(new Category { Name = "Mascotas" });
                _context.Categories.Add(new Category { Name = "Nutricion" });
                _context.Categories.Add(new Category { Name = "Ropa" });
                _context.Categories.Add(new Category { Name = "Tecnología" });

                await _context.SaveChangesAsync();
            }
        }
    }
}