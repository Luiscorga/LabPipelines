import React, { Component } from 'react';
import { useNavigate } from 'react-router-dom';
import { NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import backgroundImage from './media/Recurso6.jpg';
import taglineImage from './media/TaglineRojo.png';

export class Login extends Component {
    static displayName = Login.name;
    constructor(props) {
        super(props);

        this.state = {
            username: '',
            password: '',
        };
    }
    componentDidMount() {
        document.body.style.backgroundImage = `url(${backgroundImage})`;
        document.body.style.backgroundRepeat = 'repeat';
        document.body.style.backgroundSize = 'cover';
        document.body.style.backgroundPosition = 'top';
    }

   /* componentWillUnmount() {
        // Restaurar estilos del body en componentWillUnmount si es necesario
        document.body.style.backgroundImage = '';
        document.body.style.backgroundRepeat = '';
        document.body.style.backgroundSize = '';
        document.body.style.backgroundPosition = '';
    }*/

    handleUsernameChange = (event) => {
        this.setState({ username: event.target.value });
    }

    handlePasswordChange = (event) => {
        this.setState({ password: event.target.value });
    }

    handleSubmit = (event) => {
        useNavigate();
        event.preventDefault();

        if (this.state.username === '' || this.state.password === '') {
            alert('Please enter both username and password.');
            return;
        }

        console.log(`Logged in with username: ${this.state.username} and password: ${this.state.password}`);

        /*axios.post('https://localhost:7014/api/AutenticacionControllador', data, {
            headers: {
                'Content-Type': 'application/json'
            }
        }).then(() => {
            this.loadData();
            this.toggleFormulario(); // Cerrar el pop-up después de enviar la solicitud POST
        });*/

        window.location.reload();
    }

    render() {
        return (
            <div style={styles.h1}>
                <div style={styles.overlay}></div>
                <h1 style={styles.heading}>Iniciar Sesion</h1>
                <form style={styles.form} onSubmit={this.handleSubmit}>
                    <div style={styles.logo}></div>
                    <label htmlFor="username" style={styles.label}>Username:</label>
                    <input type="text" id="username" name="username" value={this.state.username} onChange={this.handleUsernameChange} style={styles.input} /><br />

                    <label htmlFor="password" style={styles.label}>Password:</label>
                    <input type="password" id="password" name="password" value={this.state.password} onChange={this.handlePasswordChange} style={styles.input} /><br />

                    <NavLink tag={Link} className="navbar-nav" to="/Home" style={styles.button} onClick={this.handleSubmit} >Iniciar Sesion</NavLink>
                </form>
            </div>
        );
    }
}

const styles = {
    h1: {
        fontSize: '40px', // Aumenta el tamaño del texto según tus necesidades
        fontWeight: 'bold',
        color: '#a22633',
        textAlign: 'center',
    },
    logo: {
        zIndex: '1',
        backgroundImage: `url(${taglineImage})`,
        backgroundSize: 'cover',
        backgroundPosition: 'center',
        width: '200px',
        height: '400px',
        marginRight: '10px',
    },
    overlay: {
        position: 'absolute',
        top: '0',
        left: '0',
        width: '100%',
        height: '100%',
        backgroundColor: 'rgba(0, 0, 0, 0.5)',
    },
    heading: {
        position: 'relative',
        zIndex: '1',
        margin: '0 0 30px',
        fontSize: '3rem',
        fontWeight: 'bold',
        color: '#fff',
        textAlign: 'center',
        opacity: "0%"
    },
    form: {
        position: 'relative',
        zIndex: '1',
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
        width: '430px',
        height: '450px',
        padding: '30px',
        backgroundColor: '#fff',
        borderRadius: '10px',
        boxShadow: '0 0 10px rgba(0, 0, 0, 0.2)',
        margin: 'auto',
    },
    label: {
        marginBottom: '10px',
        fontSize: '1.5rem',
        fontWeight: 'bold',
        color: '#000000',
        height: '100px',
    },
    input: {
        width: '100%',
        padding: '10px',
        marginBottom: '20px',
        border: 'none',
        borderRadius: '5px',
        backgroundColor: '#e3e3e3',
        fontSize: '1.2rem',
        color: '#000',
    },
    button: {
        width: '60%',
        height: '20%',
        padding: '5px',
        border: 'none',
        borderRadius: '40px',
        backgroundColor: '#0B4931',
        fontSize: '1.5rem',
        fontWeight: 'bold',
        color: '#fff',
        cursor: 'pointer',
        transition: 'background-color 0.3s ease',
    },
};


