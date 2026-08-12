Nos solicitan crear un programa que maneje una lista de personas y los autos que estas
poseen. Nos indican que una persona puede ser dueño de más de un auto. Pero que los
autos poseen como máximo un titular.

Una persona posee:
Características

* DNI string lectura/escritura
* Nombre string lectura/escritura
* Apellido string lectura/escritura

Métodos

* Lista_de_autos List<auto> Retorna la lista de autos que a persona es dueño.
* Cantidad_de_Autos int Retorna la cantidad de autos que posee la persona.
* Constructores: Un constructor con todos los parámetros que permiten inicializar las
propiedades.
* Finalizador: Que cuando el objeto queda liberado muestre una leyenda indicando el
DNI de la Persona.

Un auto posee:
Características

* Patente string lectura/escritura
* Marca string lectura/escritura
* Modelo string lectura/escritura
* Año string lectura/escritura
* Precio decimal lectura/escritura

Métodos
Dueño Persona Retorna el dueño del auto.

Constructores: Un constructor con todos los parámetros que permiten inicializar
propiedades.

Finalizador: Que cuando el objeto queda liberado muestre una leyenda indicando la
Patente del Auto.

Nos solicitan que la GUI (interfaz gráfica del usuario) permita visualizar en grillas
DataGridView:
1. La lista de las personas. (Grilla 1)
2. La lista de los autos. (Grilla 2)
3. Los autos de la persona seleccionado en la grilla 1. (Grilla 3)
4. Una grilla (Grilla 4) con los siguientes datos y en el siguiente orden de columnas,
para cada auto de la grilla 2. Marca, Año, Modelo, Patente, DNI del dueño,
“Apellido, Nombre”del dueño en una misma columna. (Grilla 4)

La GUI debe tener botones para:
a. Agregar personas y autos.
b. Borrar personas y autos.
c. Modificar personas y autos.
d. Asignarle a la persona selecionada en la grilla 1 el auto seleccionado en la grilla 2
La GUI debe tener un label donde se observe el valor correspondiente a la suma de los
precios de los autos de la persona seleccionada en la grilla 1.
También nos solicitan que cada valor ingresado sea validado de manera que no se
introduzcan datos inconsistentes.

Recursos a considerar para la resolución:

1. Tema Listas de programación 1. Sugerencia: Usar List(of…)
2. Tema Clses de vista.
3. Tema Clases, Instancias, Propiedades, Métodos, Constructores, Finalizadores de
la Unidad I de Programación Orientada a Objetos. Sugerencia: Ver el Orientador
y la bibliografía recomendada.
4. Tema Try … Catch
5. Tema DatagridView. Grilla vista el programación 1. Sugerencia:
https://docs.microsoft.com/es-
es/dotnet/framework/winforms/controls/datagridview-control-windows-forms
