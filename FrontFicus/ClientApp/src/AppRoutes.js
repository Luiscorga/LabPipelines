import { Login } from "./components/Login";
import { Home } from "./components/Home";
import { Eventos } from "./components/Eventos";
import { Ordenes } from "./components/Ordenes";
import { Inventario } from "./components/Inventario";
import { Clientes } from "./components/Clientes";
import { Usuarios } from "./components/Usuarios";
import { Layout } from './components/Layout';
const AppRoutes = [
    {
        index: true,
        element: <Login />
    },
    {
        path: '/Home',
        element: <Layout> <Home /></Layout>
    },
    {
        path: '/Eventos',
        element: <Layout> <Eventos /></Layout>
    },
    {
        path: '/Ordenes',
        element: <Layout> <Ordenes /></Layout>
    },
    {
        path: '/Inventario',
        element: <Layout> <Inventario /></Layout>
    },
    {
        path: '/Clientes',
        element: <Layout> <Clientes /></Layout>
    },
    {
        path: '/Usuarios',
        element: <Layout> <Usuarios /></Layout>
    }

];

export default AppRoutes;
