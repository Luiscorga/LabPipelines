import React, { Component } from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import './NavMenu.css';
import logo from './media/Isotipo6.jpg';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    render() {
        return (
            <header>
                <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
                    <NavbarBrand tag={Link} to="/">
                        <img src={logo} alt="Logo" style={{ width: '30px', height: '30px' }} />
                    </NavbarBrand>
                    <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
                    <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
                        <ul className="navbar-nav flex-grow">
                            {/*<NavItem>   <NavLink tag={Link} className="navbar-nav" to="/" style={{ color: "white" }}>Login</NavLink>   </NavItem>*/}
                            <NavItem>
                                <NavLink id="homeId"  tag={Link} className="navbar-nav" to="/Home" style={{ color: "white" }}>Home</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink id="eventosId" tag={Link} className="navbar-nav" to="/Eventos" style={{ color: "white" }}>Eventos</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink id="ordenesId" tag={Link} className="navbar-nav" to="/Ordenes" style={{ color: "white" }}>Ordenes</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink id="inventarioId" tag={Link} className="navbar-nav" to="/Inventario" style={{ color: "white" }}>Inventario</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink id="clientesId" tag={Link} className="navbar-nav" to="/Clientes" style={{ color: "white" }}>Clientes</NavLink>
                            </NavItem>
                            <NavItem>
                                <NavLink id="usuariosId" tag={Link} className="navbar-nav" to="/Usuarios" style={{ color: "white" }}>Usuarios</NavLink>
                            </NavItem>
                        </ul>
                    </Collapse>
                </Navbar>
            </header>
        );
    }
}
