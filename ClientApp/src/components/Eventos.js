import React, { Component } from 'react';
import Modal from 'react-modal';
import axios from 'axios';
import eliminar from './media/eliminar.png';
import banner_defecto from './media/banner_default.png';


export class Eventos extends Component {
    static displayName = Eventos.name;

    constructor(props) {
        super(props);
        this.state = {
            data: [],
            nombre: '',
            ubicacion: '',
            mostrarFormulario: false,
            showModal: false, // Estado para mostrar/ocultar el modal
            img: '',
            busqueda: '' // Estado de búsqueda
        };
    }

    componentDidMount() {
        this.loadData();
    }

    loadData() {
        axios.get('https://localhost:7014/api/EventoControllador')
            .then(response => {
                const data2 = response.data;
                this.setState({ data: data2 });
            });
    }

    handlenombreChange = event => {
        this.setState({ nombre: event.target.value });
    }

    handleubicacionChange = event => {
        this.setState({ ubicacion: event.target.value });
    }

    // Aplicar filtros a la tabla
    handleBusquedaChange = (event) => {
        const { value } = event.target;
        this.setState({ busqueda: value });
    };

    handleSubmit = event => {
        event.preventDefault();
        if (
            this.state.nombre === '' ||
            this.state.ubicacion === ''
        ) {
            alert('Los espacios no pueden estar incompletos');
        } else {
            let data = JSON.stringify({
                nombre: this.state.nombre,
                ubicacion: this.state.ubicacion,
                idEvento: 0
            });

            axios.post('https://localhost:7014/api/EventoControllador', data, {
                headers: {
                    'Content-Type': 'application/json'
                }
            }).then(() => {
                this.loadData();
                this.toggleFormulario(); // Cerrar el pop-up después de enviar la solicitud POST
            });
        }
    }

    toggleFormulario = () => {
        this.setState(prevState => ({
            mostrarFormulario: !prevState.mostrarFormulario,
            showModal: !prevState.showModal // Alternar el estado del modal al hacer clic en el botón
        }));
    }

    // Eliminar
    handleDelete = idEvento => {
        axios.delete(`https://localhost:7014/api/EventoControllador/${idEvento}`)
            .then(response => {
                console.log(response);
                this.loadData();
            })
            .catch(error => {
                this.loadData();
                console.log(error);
            });

    }

    render() {
        const { data, busqueda, nombre, ubicacion, idEvento, mostrarFormulario, showModal } = this.state;
        // Filtrar los eventos según la búsqueda
        const clientesFiltrados = data.filter((evento) =>
            Object.values(evento).some((value) =>
                value.toString().toLowerCase().includes(busqueda.toLowerCase())
            )
        );

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

            <div style={{ display: 'flex', flexDirection: 'column', alignItems: 'center' }}>
                <div class="grid gap-3" style={{ display: 'flex', justifyContent: 'space-between' }}>
                    <h1 style={{ color: '#0B4931', fontFamily: 'Chivo, sans-serif', fontWeight: 'bold', fontSize: '60px', marginRight: '450px', marginBottom: '30px' }}>Eventos</h1>
                    <div style={{ display: 'flex-start', flexDirection: 'column', alignItems: 'flex-end' }}>
                        <button className="opcionAgregar" onClick={this.toggleFormulario} style={{ ...botonEstilos, marginBottom: '5px', marginRight: '30px', padding: '5px' }}>
                            {mostrarFormulario ? 'Agregando Evento' : '+ Agregar Evento'}
                        </button>
                        <input
                            type="text"
                            value={busqueda}
                            onChange={this.handleBusquedaChange}
                            placeholder="Buscar"
                            style={{ ...barraEstilos, marginBottom: '10px', padding: '5px', width: '250px' }}
                        />
                    </div>
                </div>

                <div class="container text-center">
                    <div class="row row-cols-1 row-cols-md-4 g-4">
                        {clientesFiltrados.map(user => (
                            <div key={user.nombre} class="container" className="user-card" style={styles.card}>
                                <div class="col text-truncate">
                                    <img src={user.img || banner_defecto} alt="Imagen de Perfil" className="img-thumbnail" style={styles.img} />
                                    <div className="user-details">
                                        <h2 style={styles.nombre} >{user.nombre} #{user.idEvento}</h2>
                                        <p style={styles.desc} >{user.ubicacion}</p>
                                        <button
                                            onClick={() => this.handleDelete(user.idEvento)}
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
                                                src={eliminar}
                                                alt="E"
                                                style={{ width: '20px', height: '20px' }}
                                            />
                                        </button>
                                    </div>
                                </div>
                            </div>
                        ))}

                    </div>
                </div>

                <Modal
                    isOpen={showModal}
                    onRequestClose={this.toggleFormulario}
                    contentLabel="Agregar Evento"
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
                    <h2 style={{ correo: 'black' }}>Agregar Evento</h2>

                    <form onSubmit={this.handleSubmit} style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', marginTop: '20px' }}>
                        <label htmlFor="nombre" style={{ correo: 'black' }}>nombre:</label>
                        <input type="text" id="nombre" name="nombre" value={nombre} onChange={this.handlenombreChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="ubicacion" style={{ correo: 'black' }}>ubicacion:</label>
                        <input type="text" id="ubicacion" name="ubicacion" value={ubicacion} onChange={this.handleubicacionChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <div style={{ display: 'flex', justifyContent: 'space-between', marginTop: '20px' }}>
                            <button type="submit" style={{ backgroundColor: '#544ADD', correo: 'white', padding: '10px', borderRadius: '5px', border: 'none', cursor: 'pointer', marginRight: '10px' }}>Aceptar</button>
                            <button type="button" onClick={this.toggleFormulario} style={{ backgroundColor: '#DD544A', correo: 'white', padding: '10px', borderRadius: '5px', border: 'none', cursor: 'pointer', marginLeft: '10px' }}>Cancelar</button>
                        </div>

                    </form>
                </Modal>

            </div>
        );
    }
}

const styles = {
    container: {
        marginHorizontal: "auto",
        flexDirection: "column",
        justifyContent: "center"
    },
    button: {
        backgroundColor: '#544ADD',
        color: 'white',
        padding: '10px',
        borderRadius: '5px',
        border: 'none',
        cursor: 'pointer',
        alignSelf: 'flex-end'
    },
    desc: {
        marginBottom: 0,
        fontSize: '16px'
    },
    nombre: {
        fontSize: '25px',
        color: 'black',
        textOverflow: 'elipsis',
        whiteSpace: 'no-wrap',
        justifyContent: "center",
        marginBottom: '10px',
    },
    card: {
        justifyContent: "center",
        marginRight: 15,
        marginLeft: 15,
        marginTop: 10,
        marginBottom: 20,
        padding: '10px',
        borderRadius: '5px',
        border: 'none',
        width: '280px',
        height: '300px',
        position: 'static',
    },
    img: {
        padding: '10px',
        borderRadius: '5px',
        border: 'none',
        height: '200px',
        width: '100%',
        position: 'static'
    }
}