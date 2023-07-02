import React, { Component } from 'react';
import axios from 'axios';
import Modal from 'react-modal';
import eliminar from './media/eliminar.png';

export class Ordenes extends Component {
    static displayName = Ordenes.name;

    constructor(props) {
        super(props);
        this.state = {
            data: [],
            alquiler: '',
            estado: '',
            idUsuario: '',
            mostrarFormulario: false,
            showModal: false, // Estado para mostrar/ocultar el modal
            busqueda: '' // Estado de búsqueda
        };
    }

    componentDidMount() {
        this.loadData();
    }

    loadData() {
        axios.get('https://localhost:7014/api/OrdenControllador')
            .then(response => {
                const data2 = response.data;
                this.setState({ data: data2 });
            });
    }

    handlealquilerChange = event => {
        this.setState({ alquiler: event.target.value });
    }

    handleestadoChange = event => {
        this.setState({ estado: event.target.value });
    }

    handleidUsuarioChange = event => {
        this.setState({ idUsuario: event.target.value });
    }

    // Aplicar filtros a la tabla
    handleBusquedaChange = (event) => {
        const { value } = event.target;
        this.setState({ busqueda: value });
    };

    // Eliminar
    handleDelete = idOrden => {
        axios.delete(`https://localhost:7014/api/OrdenControllador/${idOrden}`)
            .then(response => {
                console.log(response);
                this.loadData();
            })
            .catch(error => {
                console.log(error);
            });

    }
    // Enviar información.
    handleSubmit = event => {
        event.preventDefault();
        if (
            this.state.alquiler === '' ||
            this.state.estado === '' ||
            this.state.idUsuario === ''
        ) {
            alert('Los espacios no pueden estar incompletos');
        } else {
            let data = JSON.stringify({
                idOrden: 0,
                alquiler: this.state.alquiler,
                estado: this.state.estado,
                idUsuario: this.state.idUsuario,
            });

            axios.post('https://localhost:7014/api/OrdenControllador', data, {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(() => {
                this.loadData();
                this.toggleFormulario(); // Cerrar el pop-up después de enviar la solicitud POST
            });
        }
    }


    toggleFormulario = () => {
        this.setState(prevState => ({
            mostrarFormulario: !prevState.mostrarFormulario,
            showModal: !prevState.showModal // Alternar el estado del modal al hacer clic en el botón
        }));
    }

    render() {

        const { data, busqueda, alquiler, estado, idUsuario, color, alquilerComercio, peso, pesoReferencia, mostrarFormulario, showModal } = this.state;
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
        return (

            <div style={{ display: 'flex', flexDirection: 'column' }}>
                <React.StrictMode>
                    <div style={{ display: 'flex', justifyContent: 'space-between' }}>
                        <h1 style={{ color: '#0B4931', fontFamily: 'Chivo, sans-serif', fontWeight: 'bold', fontSize: '60px', marginLeft: '10px' }}>Ordenes</h1>
                        <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'flex-end' }}>
                            <button className="opcionAgregar" onClick={this.toggleFormulario} style={{ ...botonEstilos, marginBottom: '5px', padding: '5px' }}>
                                {mostrarFormulario ? 'Añadiendo Orden' : '+ Añadir Orden'}
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
                                <th style={{ padding: '10px' }}>ID Orden</th>
                                <th style={{ padding: '10px' }}>Fecha de Alquiler</th>
                                <th style={{ padding: '10px' }}>Estado</th>
                                <th style={{ padding: '10px' }}>ID Usuario</th>
                                <th style={{ padding: '10px' }}>Herramientas</th>

                            </tr>
                        </thead>

                        <tbody>
                            {productosFiltrados.map((row, index) => (
                                <tr key={index} style={{ borderBottom: '1px solid black' }}>
                                    <td style={{ padding: '10px' }}>{row.idOrden}</td>
                                    <td style={{ padding: '10px' }}>{row.alquiler}</td>
                                    <td style={{ padding: '10px' }}>{row.estado}</td>
                                    <td style={{ padding: '10px' }}>{row.idUsuario}</td>
                                    <td style={{ padding: '10px' }}>
                                        <button
                                            onClick={() => this.handleDelete(row.idOrden)}
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
                                                marginTop: '-5px'
                                            }}
                                        >
                                            <img
                                                src={ eliminar }
                                                alt="E"
                                                style={{ width: '20px', height: '20px' }}
                                            />
                                        </button>
                                    </td>
                                </tr>
                            ))}
                        </tbody>

                    </table>

                    <Modal
                        isOpen={showModal}
                        onRequestClose={this.toggleFormulario}
                        contentLabel="Agregar Orden"
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
                        <h2 style={{ color: 'black' }}>Agregar Orden</h2>

                        <form onSubmit={this.handleSubmit} style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', marginTop: '20px' }}>
                            <label htmlFor="alquiler" style={{ color: 'black' }}>Alquiler:</label>
                            <input type="text" id="alquiler" name="alquiler" value={alquiler} onChange={this.handlealquilerChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                            <label htmlFor="estado" style={{ color: 'black' }}>Estado:</label>
                            <input type="text" id="estado" name="estado" value={estado} onChange={this.handleestadoChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                            <label htmlFor="idUsuario" style={{ color: 'black' }}>ID Usuario:</label>
                            <input type="text" id="idUsuario" name="idUsuario" value={idUsuario} onChange={this.handleidUsuarioChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                            <div style={{ display: 'flex', justifyContent: 'space-between', marginTop: '20px' }}>
                                <button type="submit" onSubmit={this.handleSubmit} style={{ backgroundColor: '#544ADD', color: 'white', padding: '10px', borderRadius: '5px', border: 'none', cursor: 'pointer', marginRight: '10px' }}>Aceptar</button>
                                <button type="button" onClick={this.toggleFormulario} style={{ backgroundColor: '#DD544A', color: 'white', padding: '10px', borderRadius: '5px', border: 'none', cursor: 'pointer', marginLeft: '10px' }}>Cancelar</button>
                            </div>

                        </form>
                    </Modal>
                </React.StrictMode>
            </div>
        );
    }
}
//////////////////////////////////////////////////////////////////////////////////////////

export default Ordenes;
