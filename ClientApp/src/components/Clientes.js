import React, { Component } from 'react';
import Modal from 'react-modal';
import axios from 'axios';
import eliminar from './media/eliminar.png';
import banner_defecto from './media/banner_default.png';

export class Clientes extends Component {
    static displayName = Clientes.name;

    constructor(props) {
        super(props);
        this.state = {
            data: [],
            empresa: '',
            agregado: '',
            segmento: '',
            correo: '',
            prioridad: '',
            nombreContrato: '',
            pesoDeHuellaAmb: '',
            telefono: '',
            telefono2: '',
            paginaWeb: '',
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
        axios.get(`https://localhost:7014/api/ClienteControllador`)
            .then(response => {
                const data2 = response.data;
                this.setState({ data: data2 });
            });
    }

    handleempresaChange = event => {
        this.setState({ empresa: event.target.value });
    }

    handleagregadoChange = event => {
        this.setState({ agregado: event.target.value });
    }

    handlesegmentoChange = event => {
        this.setState({ segmento: event.target.value });
    }

    handlecorreoChange = event => {
        this.setState({ correo: event.target.value });
    }

    handleprioridadChange = event => {
        this.setState({ prioridad: event.target.value });
    }

    handlenombreContratoChange = event => {
        this.setState({ nombreContrato: event.target.value });
    }

    handlepesoDeHuellaAmbChange = event => {
        this.setState({ pesoDeHuellaAmb: event.target.value });
    }

    handletelefonoChange = event => {
        this.setState({ telefono: event.target.value });
    }

    handletelefono2Change = event => {
        this.setState({ telefono2: event.target.value });
    }

    handlepaginaWebChange = event => {
        this.setState({ paginaWeb: event.target.value });
    }

    // Aplicar filtros a la tabla
    handleBusquedaChange = (event) => {
        const { value } = event.target;
        this.setState({ busqueda: value });
    };

    handleSubmit = event => {
        event.preventDefault();
        if (
            this.state.empresa === '' ||
            this.state.agregado === '' ||
            this.state.segmento === '' ||
            this.state.correo === '' ||
            this.state.prioridad === '' ||
            this.state.nombreContrato === '' ||
            this.state.pesoDeHuellaAmb === '' ||
            this.state.telefono === '' ||
            this.state.telefono2 === '' ||
            this.state.paginaWeb === ''
        ) {
            alert('Los espacios no pueden estar incompletos');
        } else {
            let data = JSON.stringify({
                empresa: this.state.empresa,
                agregado: this.state.agregado,
                segmento: this.state.segmento,
                correo: this.state.correo,
                prioridad: this.state.prioridad,
                nombreContrato: this.state.nombreContrato,
                pesoDeHuellaAmb: this.state.pesoDeHuellaAmb,
                telefono: this.state.telefono,
                telefono2: this.state.telefono2,
                paginaWeb: this.state.paginaWeb,
                idCliente: 0
            });

            axios.post('https://localhost:7014/api/ClienteControllador', data, {
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
    // Eliminar
    handleDelete = idCliente => {
        axios.delete(`https://localhost:7014/api/ClienteControllador/${idCliente}`)
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
        const { data, busqueda, empresa, agregado, segmento, correo, prioridad, nombreContrato, pesoDeHuellaAmb, telefono, telefono2, paginaWeb, mostrarFormulario, showModal } = this.state;
        // Filtrar los productos según la búsqueda
        const clientesFiltrados = data.filter((producto) =>
            Object.values(producto).some((value) =>
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
                    <h1 style={{ color: '#0B4931', fontFamily: 'Chivo, sans-serif', fontWeight: 'bold', fontSize: '60px', marginRight: '450px', marginBottom: '30px' }}>Clientes</h1>
                    <div style={{ display: 'flex-start', flexDirection: 'column', alignItems: 'flex-end' }}>
                        <button className="opcionAgregar" onClick={this.toggleFormulario} style={{ ...botonEstilos, marginBottom: '5px', marginRight: '30px', padding: '5px' }}>
                            {mostrarFormulario ? 'Agregando Cliente' : '+ Agregar Cliente'}
                        </button>
                        <input
                            type="text"
                            value={busqueda}
                            onChange={this.handleBusquedaChange}
                            placeholder="Buscar"
                            style={{ ...barraEstilos, marginBottom: '18px', padding: '5px', width: '250px' }}
                        />
                    </div>
                </div>

                <div class="container text-center">
                    <div class="row row-cols-1 row-cols-md-3 g-4">
                        {clientesFiltrados.map(user => (
                            <div key={user.empresa} class="container" className="user-card" style={styles.card}>
                                <div class="col text-truncate">
                                    <img src={user.img || banner_defecto} alt="Imagen de Perfil" className="img-thumbnail" style={styles.img} />
                                    <div className="user-details">
                                        <h2 style={styles.nombre} >{user.empresa}</h2>
                                        <p style={styles.desc} >{user.segmento}</p>
                                        <p style={styles.desc} >{user.prioridad} </p>
                                        <button
                                            onClick={() => this.handleDelete(user.idCliente)}
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
                    contentLabel="Agregar Cliente"
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
                    <h2 style={{ correo: 'black' }}>Agregar Cliente</h2>

                    <form onSubmit={this.handleSubmit} style={{ display: 'flex', flexDirection: 'column', alignItems: 'center', marginTop: '20px' }}>
                        <label htmlFor="empresa" style={{ correo: 'black' }}>Empresa:</label>
                        <input type="text" id="empresa" name="empresa" value={empresa} onChange={this.handleempresaChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="agregado" style={{ correo: 'black' }}>Agregado:</label>
                        <input type="text" id="agregado" name="agregado" value={agregado} onChange={this.handleagregadoChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="segmento" style={{ correo: 'black' }}>Segmento:</label>
                        <input type="text" id="segmento" name="segmento" value={segmento} onChange={this.handlesegmentoChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="correo" style={{ correo: 'black' }}>Correo:</label>
                        <input type="text" id="correo" name="correo" value={correo} onChange={this.handlecorreoChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="prioridad" style={{ correo: 'black' }}>Prioridad:</label>
                        <input type="text" id="prioridad" name="prioridad" value={prioridad} onChange={this.handleprioridadChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="nombreContrato" style={{ correo: 'black' }}>Nombre de Contrato:</label>
                        <input type="text" id="nombreContrato" name="nombreContrato" value={nombreContrato} onChange={this.handlenombreContratoChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="pesoDeHuellaAmb" style={{ correo: 'black' }}>Peso De Huella Ambiental:</label>
                        <input type="text" id="pesoDeHuellaAmb" name="pesoDeHuellaAmb" value={pesoDeHuellaAmb} onChange={this.handlepesoDeHuellaAmbChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="telefono" style={{ correo: 'black' }}>Telefono (primario):</label>
                        <input type="text" id="telefono" name="telefono" value={telefono} onChange={this.handletelefonoChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="telefono2" style={{ correo: 'black' }}>Telefono (secundario):</label>
                        <input type="text" id="telefono2" name="telefono2" value={telefono2} onChange={this.handletelefono2Change} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

                        <label htmlFor="paginaWeb" style={{ correo: 'black' }}>Pagina Web:</label>
                        <input type="text" id="paginaWeb" name="paginaWeb" value={paginaWeb} onChange={this.handlepaginaWebChange} style={{ padding: '5px', borderRadius: '5px', border: '1px solid purple', marginBottom: '10px' }} />

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
        fontSize: '18px'
    },
    nombre: {
        fontSize: '25px',
        color: 'black',
        textOverflow: 'elipsis',
        whiteSpace: 'no-wrap',
        justifyContent: "center"
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
        width: '30%',
        position: 'static',
    },
    img: {
        padding: '10px',
        borderRadius: '5px',
        border: 'none',
        height: '100%',
        width: '100%',
        position: 'static'
    }
}