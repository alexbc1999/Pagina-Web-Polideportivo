# Pagina-Web-Polideportivo
 Proyecto grupal de Desarrollo de Página Web desde 0. Con C# y Asp.NET.
 
 Práctica grupal de la asignatura Herramientas Avanzadas de Desarrollo de Aplicaciones (HADA).

EN LA RAMA DOCUMENTATION, ENCONTRAREMOS LAS BASES DE DATOS, LOS DIAGRAMAS Y LA PRESENTACIÓN DE LA PRÁCTICA FINAL.

Nombre miembros grupo (Gossifleur): Daniel Sentamans Lorente, Mohammed Derfoufi, Alejandro Bernabeu Calatayud.

Turno: Viernes de 13:00 - 15:00

Descripción Página Web para gestionar un Polideportivo donde se pueden hacer reservas de pistas y actividades. Nos daremos de alta como usuario iniciando sesión o registrándose.

Parte pública:

-Ofrecer el login --> Habrá dos tipos de login, uno de Administrador que tendrá más permisos y otro como usuario para acceder a las partes privadas de la página. -Ver pistas --> Posibilidad de ver las difentes pistas como su descripción, imágenes y disponibilidad. -Ver Notícias --> Poder visualizar las últimas notícias con respecto al polideportivo, tales como consejos, avisos, cambio de horarios... -Ver actividades --> Se pueden visualizar las distintas actividades que se llevan a cabo como su descripción, profesor que las imparte, horario, precio, nivel. -Ver contacto --> Podremos visualizar los datos de contacto y localización del polideportivo

Listado EN Pública: -ENPista --> pistas con atributos que la definan. -ENNoticias --> noticias con su descripción. -ENActividad --> actividades y sus diferentes características.

Parte privada: -Reservar una pista --> Podremos reservar una pista en una hora determinada. -Matricularse en actividades --> Se podrá matricular un usuario en una o varias actividades. -Editar perfil --> Podrás configurar tu perfil de usuario. -Visualizar Agenda --> El usuario podrá ver sus reservas y sus clases a una determinada hora. -Privilegios Administrador --> El administrador podrá cambiar, insertar y borrar tanto clases como horarios. -Nivel del Usuario --> El usuarió podrá llegar a tener 3 niveles dependiendo de su participación tanto en actividades como en reservas de pistas. Y tener distintas ofertas dependiendo del nivel.

Listado EN privada: -ENReserva --> el usuario reservará un tipo pista en un horario. -ENUsuario --> el usuario podrá reservar, matricularse en actividades... -ENHorario --> horario donde se mostrará hora y día de la reserva. -ENAgenda --> cada usuarió podrá ver sus actividades y reservas. -ENNivel --> cada usuarió tendrá un nivel dependiendo de sus reservas o actividades.

Posibles mejoras:

-Localización. -Añadir redes sociales. -Mostrar calendario. -Mostrar en la página de inicio los distintos eventos en un diseño de imágenes. -Vincular tu reserva al calendario de Google de tu smartphone. ...

Para acceder introduzca: Usuario: admin Contraseña: admin Usuario: user Contraseña: user

Tareas realizadas: Ver pistas (ENPista, CADpista), Reservar pistas (ENReservaPista, CADReservaPista), Ver y Crear Noticias (ENNoticia, CADNoticia), Ver Contacto (Contacto aspx) y mostrar el Calendario de las Reservas de pistas (Calendario aspx), ofrecer el login (CADUsuario, ENUsuario), interfaz de usuario, crear usuarios, añadir usuario a administrador (ENAdministrador, CADAdministrador, ENTarjetaSocio, CadTarjetaSocio), Ver Actividades(ENActividad, CADActividad), Reservar Actividades (ENReservaActividad, CADReservaActividad)
