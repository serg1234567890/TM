import './custom.css'
import { Route, Routes } from 'react-router';
import Counter from './components/Counter';
import PrivateRoute from './components/Auth/PrivateRoute';
import Login from './components/Auth/Login';
import NavMenu from './components/NavMenu';
import Monitor from './components/Monitor/Monitor';
import Home from './components/Home';

const App: React.FunctionComponent = () => {
    return <>
        <NavMenu />
        <Routes>
            <Route path='/' element={<PrivateRoute> <Home /> </PrivateRoute>} />
            <Route path='/counter' element={<Counter/>} />
            <Route path='/monitor' element={<Monitor />} />
            <Route path='/login' element={<Login />} />
        </Routes>
    </>
}

export default App;
