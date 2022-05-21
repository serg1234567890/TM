import './custom.css'
import { Route, Routes } from 'react-router';
import Counter from './components/Counter';
import Home from './components/Home';
import FetchData from './components/FetchData';

const App: React.FunctionComponent = () => {
    return <>
        <Routes>
            <Route path='/' element={<Home/>} />
            <Route path='/counter' element={<Counter/>} />
            <Route path='/fetch-data' element={<FetchData/>} />
        </Routes>
    </>
}

export default App;
