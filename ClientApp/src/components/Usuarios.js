import React, { Component } from 'react';
import Modal from 'react-modal';
import img_defecto from './media/imagen-perfil.png';
import eliminar from './media/eliminar.png';
import './UserInfo.css';
import axios from 'axios';

export class Usuarios extends Component {
    static displayName = Usuarios.name;

    constructor(props) {
        super(props);
        this.state = {
            data: [],
            pNombre: '',
            pApellido: '',
            sApellido: '',
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
        axios.get('https://localhost:7014/api/UsuarioControllador')
            .then(response => {
                const data2 = response.data;
                this.setState({ data: data2 });
            });
    }

    handlepNombreChange = event => {
        this.setState({ pNombre: event.target.value });
    }

    handlepApellidoChange = event => {
        this.setState({ pApellido: event.target.value });
    }

    handlesApellidoChange = event => {
        this.setState({ sApellido: event.target.value });
    }


    // Aplicar filtros a la tabla
    handleBusquedaChange = (event) => {
        const { value } = event.target;
        this.setState({ busqueda: value });
    };

    handleSubmit = event => {
        event.preventDefault();
        if (
            this.state.pNombre === '' ||
            this.state.pApellido === ''
        ) {
            alert('Los espacios no pueden estar incompletos');
        } else {
            let data = JSON.stringify({
                pNombre: this.state.pNombre,
                pApellido: this.state.pApellido,
                sApellido: this.state.sApellido,
                idUsuario: 0
            });

            axios.post('https://localhost:7014/api/UsuarioControllador', data, {
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
    handleDelete = idCliente => {
        axios.delete(`https://localhost:7014/api/UsuarioControllador/${idCliente}`)
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
        const { data, busqueda, pNombre, pApellido, sApellido, mostrarFormulario, showModal } = this.state;
        // Filtrar los Clientes según la búsqueda
        const usuariosFiltrados = data.filter((Cliente) =>
            Object.values(Cliente).some((value) =>
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
                    <h1 style={{ color: '#0B4931', fontFamily: 'Chivo, sans-serif', fontWeight: 'bold', fontSize: '60px', marginRight: '450px' }}>Usuarios</h1>
                    <div style={{ display: 'flex-start', flexDirection: 'column', alignItems: 'flex-end' }}>
                        <button className="opcionAgregar" onClick={this.toggleFormulario} style={{ ...botonEstilos, marginBottom: '5px', marginRight: '30px', padding: '5px' }}>
                            {mostrarFormulario ? 'Agregando Usuario' : '+ Agregar Usuario'}
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

                {/* this is the Card*/}
                <div className="user-info">
                    <div class="container-fluid">
                        <div class="row row-cols-1 row-cols-4 g-4 grid gap-2 ">
                            {usuariosFiltrados.map(user => (
                                <div key={user.pNombre} className="user-card" style={styles.card}>
                                    <img src={user.img || img_defecto} alt="Profile" className="profile-picture" style={styles.img} />
                                    <div class="text-truncate">
                                        <div className="user-details">
                                            <h2 style={styles.nombre} >{user.pNombre} {user.pApellido}</h2>
                                            <p style={styles.desc} >Tipo de Usuario</p>
                                            <button
                                                onClick={() => this.handleDelete(user.idUsuario)}
                                                style={{
                                                    background: 'red',
                                                    border: 'none',
                                                    borderRadius: '20%',
                                                    width: '30px',
                                                    height: '30px',
                                                    padding: '0',
                                                    display: 'flex',
                                                    justifyContent: 'center',
                                                    alignItems: 'center',

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
                </div>

                <Modal
                    isOpen={showModal}
                    onRequestClose={this.toggleFormulario}
                    contentLabel="Agregar Usuario"
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
                    <h2 style={{ correo: 'black' }}>Agregar Usuario</h2>

                    <form onSubmit={this.handleSubmit} style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', marginTop: '20px' }}>
                        <label htmlFor="pNombre" style={{ correo: 'black' }}>Nombre:</label>
                        <input type="text" id="pNombre" name="pNombre" value={pNombre} onChange={this.handlepNombreChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="pApellido" style={{ correo: 'black' }}>Primer Apellido:</label>
                        <input type="text" id="pApellido" name="pApellido" value={pApellido} onChange={this.handlepApellidoChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="sApellido" style={{ correo: 'black' }}>Segundo Apellido:</label>
                        <input type="text" id="sApellido" name="sApellido" value={sApellido} onChange={this.handlesApellidoChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

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
        marginBottom: 3,
        fontSize: '17.7px'
    },
    nombre: {
        marginTop: 3,
        fontSize: '20px',
        color: 'black',
        textOverflow: 'elipsis',
        whiteSpace: 'no-wrap',
        justifyContent: "center",
    },
    card: {
        marginRight: 0,
        marginLeft: 5,
        marginTop: 0,
        marginBottom: 10,
        padding: '10px',
        borderRadius: '5px',
        border: 'none',
        width: '300px',
        position: 'relative',
        top: 0,
        start: 0
    },
    img: {
        height: '70px',
        width: '70px',
    }
}