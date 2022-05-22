import './custom.css'
import { Route, Routes } from 'react-router';
import Counter from './components/Counter';
import Home from './components/Home';
import FetchData from './components/FetchData';
import PrivateRoute from './components/Auth/PrivateRoute';

const App: React.FunctionComponent = () => {
    return <>
        <Routes>
            <Route path='/' element={<PrivateRoute> <Home /> </PrivateRoute>} />
            <Route path='/counter' element={<Counter/>} />
            <Route path='/fetch-data' element={<FetchData/>} />
        </Routes>
    </>
}

export default App;
