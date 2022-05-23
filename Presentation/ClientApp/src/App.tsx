import './custom.css'
import { Route, Routes } from 'react-router';
import PrivateRoute from './components/Auth/PrivateRoute';
import Login from './components/Auth/Login';
import Monitor from './components/Monitor/Monitor';
import HistoryData from './components/Monitor/HistoryData';

const App: React.FunctionComponent = () => {
    return <>
        <Routes>
            <Route path='/' element={<PrivateRoute> <Monitor /> </PrivateRoute>} />
            <Route path='/monitor' element={<Monitor />} />
            <Route path='/history' element={<HistoryData />} />
            <Route path='/login' element={<Login />} />
        </Routes>
    </>
}

export default App;
