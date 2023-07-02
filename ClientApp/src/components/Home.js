import React, { Component } from 'react';
import backgroundImage from './media/Recurso2.jpg'; 

export class Home extends Component {
  static displayName = Home.name;
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div style={styles.formEstadisticas}>
                <div style={styles.formOrdenes}></div>
            </div>
        );
    }
}

const styles = {
    formEstadisticas: {
        position: 'relative',
        zIndex: '1',
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'center',
        justifyContent: 'center',
        width: '650px',
        height: '400px',
        padding: '10px',
        backgroundColor: '#fff',
        borderRadius: '10px',
        boxShadow: '0 0 10px rgba(0, 0, 0, 0.2)',
        margin: 'auto',
    },
    formOrdenes: {
        position: 'relative',
        zIndex: '',
        display: 'flex',
        flexDirection: 'column',
        alignItems: 'right',
        justifyContent: 'center',
        width: '650px',
        height: '400px',
        padding: '10px',
        backgroundColor: '#fff',
        borderRadius: '10px',
        boxShadow: '0 0 10px rgba(0, 0, 0, 0.2)',
        margin: 'auto',
    }
};


