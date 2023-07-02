import React, { Component } from 'react';
import axios from 'axios';
import Modal from 'react-modal';
import eliminar from './media/eliminar.png';
import comprobado from './media/check.gif';
import cargando from './media/cargando.gif';
import modificar from './media/modificar.png';


export class Inventario extends Component {
    static displayName = Inventario.name;

    constructor(props) {
        super(props);
        this.state = {
            data: [],
            nombre: '',
            alquilerRetail: '',
            descripcion: '',
            color: '',
            alquilerComercio: '',
            peso: '',
            pesoReferencia: '',
            idFamilia: '',
            mostrarFormulario: false,
            showModal: false, // Estado para mostrar/ocultar el modal
            busqueda: '', // Estado de búsqueda
            showSuccessModal: false, // Estado para mostrar/ocultar el modal de éxito
            errorIngreso: "", // Error para indicar solo números.
            isModalOpen: false,
            mostrarPopup: false, // indicador de mostrar/ocultar pop-up de edición
            productoSeleccionado: null
        };
    }

    componentDidMount() {
        this.loadData();
    }

    loadData() {
        axios.get('https://localhost:7014/api/ProductoControllador')
            .then(response => {
                const data2 = response.data;
                this.setState({ data: data2 });
            });
    }

    handlenombreChange = event => {
        this.setState({ nombre: event.target.value });
    }

    handlealquilerRetailChange = event => {
        this.setState({ alquilerRetail: event.target.value });
    }

    handledescripcionChange = event => {
        this.setState({ descripcion: event.target.value });
    }

    handlecolorChange = event => {
        this.setState({ color: event.target.value });
    }

    handlealquilerComercioChange = event => {
        this.setState({ alquilerComercio: event.target.value });
    }

    handlepesoChange = event => {
        this.setState({ peso: event.target.value });
    }

    handlepesoReferenciaChange = event => {
        this.setState({ pesoReferencia: event.target.value });
    }

    handleFamiliaChange = event => {
        this.setState({ idFamilia: event.target.value });
    }

    // Aplicar filtros a la tabla
    handleBusquedaChange = (event) => {
        const { value } = event.target;
        this.setState({ busqueda: value });
    };
    // Pop-up de eliminar
    openModal = () => {
        this.setState({ isModalOpen: true });
    };

    closeModal = () => {
        this.setState({ isModalOpen: false });
    };


    // Eliminar
    handleDelete = sku => {
        this.openModal();
        this.setState({ skuToDelete: sku }); // Guarda el SKU en el estado para usarlo después
    };

    handleConfirmDelete = () => {
        const skuToDelete = this.state.skuToDelete;

        axios
            .delete(`https://localhost:7014/api/ProductoControllador/${skuToDelete}`)
            .then(response => {
                console.log(response);
                this.loadData();
            })
            .catch(error => {
                console.log(error);
            });

        this.closeModal(); // Cierra el pop-up después de la confirmación
        this.setState({ showSuccessModal: true });
        setTimeout(this.hideSuccessModal, 1750);
    };

    // Mostrar op-up de realizado correctamente.
    showSuccessModal = () => {
        this.setState({ showSuccessModal: true });
    };
    // Esconder pop-up de realizado correctamente.
    hideSuccessModal = () => {
        this.setState({ showSuccessModal: false });
    };



    // Enviar información.
    handleSubmit = event => {
        event.preventDefault();
        if (
            this.state.nombre === '' ||
            this.state.alquilerRetail === '' ||
            this.state.descripcion === '' ||
            this.state.color === '' ||
            this.state.alquilerComercio === '' ||
            this.state.peso === '' ||
            this.state.pesoReferencia === '' ||
            this.state.idFamilia === '' // Se verifica también la variable familia
        ) {
            alert('Los espacios no pueden estar incompletos');
        } else {
            let data = JSON.stringify({
                sku: 0,
                nombre: this.state.nombre,
                alquilerRetail: this.state.alquilerRetail,
                descripcion: this.state.descripcion,
                color: this.state.color,
                alquilerComercio: this.state.alquilerComercio,
                peso: this.state.peso,
                pesoReferencia: this.state.pesoReferencia,
                idFamilia: this.state.idFamilia
            });

            axios.post('https://localhost:7014/api/ProductoControllador', data, {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(() => {
                this.loadData();
                this.toggleFormulario(); // Cerrar el pop-up después de enviar la solicitud POST
                this.setState({ showSuccessModal: true });
                setTimeout(this.hideSuccessModal, 1750);

            });
        }
    }

    toggleFormulario = () => {
        this.setState(prevState => ({
            mostrarFormulario: !prevState.mostrarFormulario,
            showModal: !prevState.showModal // Alternar el estado del modal al hacer clic en el botón
        }));
    }

    // Modificaciones
    handleModify = (producto) => {
        const sku = producto.sku;
        let data = JSON.stringify({
            sku: producto.sku,
            nombre: producto.nombre,
            alquilerRetail: producto.alquilerRetail,
            descripcion: producto.descripcion,
            color: producto.color,
            alquilerComercio: producto.alquilerComercio,
            peso: producto.peso,
            pesoReferencia: producto.pesoReferencia,
            idFamilia: producto.idFamilia
        });

        axios.put(`https://localhost:7014/api/ProductoControllador/${sku}`, data, {
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(() => {
            this.loadData();
            this.setState({ showSuccessModal: true });
            setTimeout(this.hideSuccessModal, 1750);
        });
    }

    handleModificarClick = (producto) => {
        console.log('intentooo: ');
        this.setState({ productoSeleccionado: producto, mostrarPopup: true });
    }

    // Handle para cambios en los parametros existentes.
    handleNombreExistenteChange = (event) => {
        const { productoSeleccionado } = this.state;
        const nuevoNombre = event.target.value;
        this.setState({
            productoSeleccionado: {
                ...productoSeleccionado,
                nombre: nuevoNombre
            }
        });
    }
    handleAlquilerRetailExistenteChange = (event) => {
        const { productoSeleccionado } = this.state;
        const nuevoAlquilerRetail = event.target.value;
        this.setState({
            productoSeleccionado: {
                ...productoSeleccionado,
                alquilerRetail: nuevoAlquilerRetail
            }
        });
    }

    handleColorExistenteChange = (event) => {
        const { productoSeleccionado } = this.state;
        const nuevoColor = event.target.value;
        this.setState({
            productoSeleccionado: {
                ...productoSeleccionado,
                color: nuevoColor
            }
        });
    }

    handleDescripcionExistenteChange = (event) => {
        const { productoSeleccionado } = this.state;
        const nuevaDescripcion = event.target.value;
        this.setState({
            productoSeleccionado: {
                ...productoSeleccionado,
                descripcion: nuevaDescripcion
            }
        });
    }

    handleAlquilerComercioExistenteChange = (event) => {
        const { productoSeleccionado } = this.state;
        const nuevoAlquilerComercio = event.target.value;
        this.setState({
            productoSeleccionado: {
                ...productoSeleccionado,
                alquilerComercio: nuevoAlquilerComercio
            }
        });
    }

    handlePesoExistenteChange = (event) => {
        const { productoSeleccionado } = this.state;
        const nuevoPeso = event.target.value;
        this.setState({
            productoSeleccionado: {
                ...productoSeleccionado,
                peso: nuevoPeso
            }
        });
    }

    handlePesoReferenciaExistenteChange = (event) => {
        const { productoSeleccionado } = this.state;
        const nuevoPesoReferencia = event.target.value;
        this.setState({
            productoSeleccionado: {
                ...productoSeleccionado,
                pesoReferencia: nuevoPesoReferencia
            }
        });
    }

    handleIdFamiliaExistenteChange = (event) => {
        const { productoSeleccionado } = this.state;
        const nuevoIdFamilia = event.target.value;
        this.setState({
            productoSeleccionado: {
                ...productoSeleccionado,
                idFamilia: nuevoIdFamilia
            }
        });
    }


    // Handle pra los botones de aceptar y cancelar de modificacion.
    handleAceptarClick = () => {
        const { productoSeleccionado } = this.state;
        this.handleModify(productoSeleccionado);
        this.setState({ mostrarPopup: false });
    }

    handleCancelarClick = () => {
        this.setState({ mostrarPopup: false });
    }



    render() {
        
        const { data, busqueda, nombre, alquilerRetail, descripcion, color, alquilerComercio, peso, pesoReferencia, mostrarFormulario, showModal, showSuccessModal, mostrarPopup,
           productoSeleccionado } = this.state;
        //Verificar numeros
        function soloNumeros(event) {
            if (event.which < 48 || event.which > 57) {
                event.preventDefault();
                this.setState({ errorIngreso: "Por favor ingrese un número" });
            } else {
                this.setState({ errorIngreso: "" });
            }
        }

        // Filtrar los productos según la búsqueda
        const productosFiltrados = data.filter((producto) =>
            Object.values(producto).some((value) =>
                value && value.toString().toLowerCase().includes(busqueda.toLowerCase())
            )
        );
        // Estilos de los botones y barra.
        const botonEstilos = {
            backgroundColor: '#544ADD',
            color: 'white',
            padding: '10px',
            borderRadius: '5px',
            border: 'none',
            cursor: 'pointer',
            alignSelf: 'flex-end',
            marginBottom: '10px'
        };
        const barraEstilos = {
            color: '#544ADD',
            padding: '10px',
            borderRadius: '5px',
            border: 'none',
            cursor: 'pointer',
            alignSelf: 'flex-end',
            marginBottom: '10px'
        };

        if (data.length === 0) {
            return (
                <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '200px' }}>
                    <img src={cargando} alt="Cargando..." style={{ width: '50%' }} />
                </div>
            );
        }
        return (

            <div style={{ display: 'flex', flexDirection: 'column' }}>
                <React.StrictMode>
                    <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                        <h1 style={{ color: '#0B4931', fontFamily: 'Chivo, sans-serif', fontWeight: 'bold', fontSize: '60px', marginLeft: '10px' }}>Inventario</h1>
                        <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'flex-end' }}>
                            <button className="opcionAgregar" onClick={this.toggleFormulario} style={{ ...botonEstilos, marginBottom: '5px', padding: '5px' }}>
                                {mostrarFormulario ? 'Añadiendo Producto' : '+ Añadir Producto'}
                            </button>
                            <input
                                type="text"
                                value={busqueda}
                                onChange={this.handleBusquedaChange}
                                placeholder="Buscar"
                                style={{ ...barraEstilos, marginBottom: '10px', padding: '5px' }}
                            />
                        </div>
                    </div>

                
                    <table style={{ borderCollapse: 'collapse', borderRadius: '10px', overflow: 'hidden', backgroundColor: 'white' }}>
                        <thead style={{ backgroundColor: '#F7E6D0', color: 'black' }}>
                            <tr>
                                <th style={{ padding: '10px' }}>SKU</th>
                                <th style={{ padding: '10px' }}>Nombre</th>
                                <th style={{ padding: '10px' }}>Alquiler Retail</th>
                                <th style={{ padding: '10px' }}>Color</th>
                                <th style={{ padding: '10px' }}>Descripción</th>
                                <th style={{ padding: '10px' }}>Alquiler Comercio</th>
                                <th style={{ padding: '10px' }}>Peso</th>
                                <th style={{ padding: '10px' }}>Peso Referencia</th>
                                <th style={{ padding: '10px' }}>idFamilia</th> 
                                <th style={{ padding: '10px' }}>Herramientas</th> 

                            </tr>
                        </thead>

                        <tbody>
                            {productosFiltrados.map((row, index) => (
                                <tr key={index} style={{ borderBottom: '1px solid black' }}>
                                    <td style={{ padding: '10px' }}>{row.sku}</td>
                                    <td style={{ padding: '10px' }}>{row.nombre}</td>
                                    <td style={{ padding: '10px' }}>{row.alquilerRetail}</td>
                                    <td style={{ padding: '10px' }}>{row.color}</td>
                                    <td style={{ padding: '10px' }}>{row.descripcion}</td>
                                    <td style={{ padding: '10px' }}>{row.alquilerComercio}</td>
                                    <td style={{ padding: '10px' }}>{row.peso}</td>
                                    <td style={{ padding: '10px' }}>{row.pesoReferencia}</td>
                                    <td style={{ padding: '10px' }}>{row.idFamilia}</td>
                                    <td style={{ padding: '10px' }}>
                                        <div style={{ display: 'flex', alignItems: 'center' }}>
                                            <button
                                                onClick={() => this.handleModificarClick(row)}
                                                style={{
                                                    background: 'green',
                                                    border: 'none',
                                                    borderRadius: '50%',
                                                    width: '30px',
                                                    height: '30px',
                                                    padding: '0',
                                                    display: 'flex',
                                                    justifyContent: 'center',
                                                    alignItems: 'center',
                                                    marginTop: '-5px',
                                                    marginRight: '5px' // Espacio entre los botones
                                                }}
                                            >
                                                <img
                                                    src={modificar}
                                                    alt="E"
                                                    style={{ width: '20px', height: '20px' }}
                                                />
                                            </button>

                                            <button
                                                onClick={() => this.handleDelete(row.sku)}
                                                style={{
                                                    background: 'red',
                                                    border: 'none',
                                                    borderRadius: '50%',
                                                    width: '30px',
                                                    height: '30px',
                                                    padding: '0',
                                                    display: 'flex',
                                                    justifyContent: 'center',
                                                    alignItems: 'center',
                                                    marginTop: '-5px',
                                                    marginLeft: '20px' 
                                                }}
                                            >
                                                <img
                                                    src={eliminar}
                                                    alt="E"
                                                    style={{ width: '20px', height: '20px' }}
                                                />
                                            </button>
                                        </div>
                                    </td>
                                </tr>
                            ))}
                        </tbody>
                        
                </table>
                 
                <Modal
                    isOpen={showModal}
                    onRequestClose={this.toggleFormulario}
                    contentLabel="Agregar Producto"
                    style={{
                        overlay: {
                            backgroundColor: 'rgba(0, 0, 0, 0.5)'
                        },
                        content: {
                            width: '400px',
                            margin: 'auto',
                            padding: '20px',
                            borderRadius: '5px',
                            backgroundColor: '#fff',
                            display: 'flex',
                            flexDirection: 'column',
                            alignItems: 'center'
                        }
                    }}
                >
                    <h2 style={{ color: 'black' }}>Agregar Producto</h2>

                    <form onSubmit={this.handleSubmit} style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', marginTop: '20px' }}>
                        <label htmlFor="nombre" style={{ color: 'black' }}>Nombre:</label>
                        <input type="text" id="nombre" name="nombre" value={nombre} onChange={this.handlenombreChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="alquilerRetail" style={{ color: 'black' }}>Alquiler de Renta:</label>
                        <input type="text" id="alquilerRetail" name="alquilerRetail" value={alquilerRetail} onChange={this.handlealquilerRetailChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="descripcion" style={{ color: 'black' }}>Descripcion:</label>
                        <input type="text" id="descripcion" name="descripcion" value={descripcion} onChange={this.handledescripcionChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="color" style={{ color: 'black' }}>Color:</label>
                        <input type="text" id="color" name="color" value={color} onChange={this.handlecolorChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="alquilerComercio" style={{ color: 'black' }}>Alquiler De Comercio:</label>
                        <input type="text" id="alquilerComercio" name="alquilerComercio" value={alquilerComercio} onChange={this.handlealquilerComercioChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="peso" style={{ color: 'black' }}>Peso:</label>
                        <input type="text" id="peso" name="peso" value={peso} onChange={this.handlepesoChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="pesoReferencia" style={{ color: 'black' }}>Peso De Referencia:</label>
                        <input type="text" id="pesoReferencia" name="pesoReferencia" value={pesoReferencia} onChange={this.handlepesoReferenciaChange}  style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="idFamilia" style={{ color: 'black' }}>idFamilia:</label>
                        <input type="text" id="idFamilia" name="idFamilia" value={this.state.idFamilia} onChange={this.handleFamiliaChange} onKeyPress={soloNumeros.bind(this)} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />
                        <span style={{ color: "red" }}>{this.state.errorIngreso}</span>
                        
                        <div style={{ display: 'flex', justifyContent: 'space-between', marginTop: '20px' }}>
                            <button type="submit" onSubmit={this.handleSubmit}  style={{ backgroundColor: '#544ADD', color: 'white', padding: '10px', borderRadius: '5px', border: 'none', cursor: 'pointer', marginRight: '10px' }}>Aceptar</button>
                            <button type="button" onClick={this.toggleFormulario} style={{ backgroundColor: '#DD544A', color: 'white', padding: '10px', borderRadius: '5px', border: 'none', cursor: 'pointer', marginLeft: '10px' }}>Cancelar</button>
                        </div>

                    </form>
                      
                    </Modal>

                    <Modal
                        isOpen={showSuccessModal}
                        onRequestClose={this.hideSuccessModal}
                        contentLabel="Éxito"
                        style={{
                            overlay: {
                                backgroundColor: 'rgba(0, 0, 0, 0.5)'
                            },
                            content: {
                                width: '400px',
                                margin: 'auto',
                                padding: '20px',
                                borderRadius: '5px',
                                backgroundColor: '#fff',
                                display: 'flex',
                                flexDirection: 'column',
                                alignItems: 'center',
                                justifyContent: 'flex-start',
                                height: '280px' 
                            }
                        }}
                    >
                        <img src={comprobado} alt="GIF de éxito" style={{ width: '50%' }} />
                        <p style={{ fontWeight: 'bold' }}>Se ha efectuado la acción correctamente.</p>
                    </Modal>

                    <Modal
                        isOpen={this.state.isModalOpen}
                        onRequestClose={this.closeModal}
                        contentLabel="Confirmación de eliminación"
                        style={{
                            overlay: {
                                backgroundColor: 'rgba(0, 0, 0, 0.5)'
                            },
                            content: {
                                width: '400px',
                                margin: 'auto',
                                padding: '20px',
                                borderRadius: '5px',
                                backgroundColor: '#fff',
                                display: 'flex',
                                flexDirection: 'column',
                                alignItems: 'center',
                                justifyContent: 'flex-start',
                                height: '250px'
                            }
                        }}
                    >
                        <h3 style={{ textAlign: 'center' }} >¿Realmente quieres eliminar este elemento?</h3>
                        <div style={{ display: 'flex', justifyContent: 'space-between', marginTop: '20px' }}>
                            <button onClick={this.handleConfirmDelete} style={{ backgroundColor: '#544ADD', color: 'white', padding: '10px', borderRadius: '5px', border: 'none', cursor: 'pointer', marginRight: '10px' }}>Aceptar</button>
                            <button onClick={this.closeModal} style={{ backgroundColor: '#DD544A', color: 'white', padding: '10px', borderRadius: '5px', border: 'none', cursor: 'pointer', marginLeft: '10px' }}>Cancelar</button>
                        </div>
                    </Modal>

                    {mostrarPopup && (
                        <div className="popup">
                            <h2>Modificar Producto</h2>
                            <input
                                type="text"
                                value={productoSeleccionado.nombre}
                                onChange={this.handleNombreExistenteChange}
                            />
                            <input
                                type="text"
                                value={productoSeleccionado.alquilerRetail}
                                onChange={this.handleAlquilerRetailExistenteChange}
                            />
                            <input
                                type="text"
                                value={productoSeleccionado.color}
                                onChange={this.handleColorExistenteChange}
                            />
                            <input
                                type="text"
                                value={productoSeleccionado.descripcion}
                                onChange={this.handleDescripcionExistenteChange}
                            />
                            <input
                                type="text"
                                value={productoSeleccionado.alquilerComercio}
                                onChange={this.handleAlquilerComercioExistenteChange}
                            />
                            <input
                                type="text"
                                value={productoSeleccionado.peso}
                                onChange={this.handlePesoExistenteChange}
                            />
                            <input
                                type="text"
                                value={productoSeleccionado.pesoReferencia}
                                onChange={this.handlePesoReferenciaExistenteChange}
                            />
                            <input
                                type="text"
                                value={productoSeleccionado.idFamilia}
                                onChange={this.handleIdFamiliaExistenteChange}
                            />

                            <button onClick={this.handleAceptarClick}>Aceptar</button>
                            <button onClick={this.handleCancelarClick}>Cancelar</button>
                        </div>
                    )}


                </React.StrictMode>
            </div>

        );
    }
}
//////////////////////////////////////////////////////////////////////////////////////////

export default Inventario;
