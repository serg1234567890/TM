import './custom.css'
import { Route, Switch } from 'react-router';
import Counter from './components/Counter';
import Home from './components/Home';
import FetchData from './components/FetchData';

const App: React.FunctionComponent = () => {
    return <>
        <Switch>
            <Route exact path='/' component={Home} />
            <Route path='/counter' component={Counter} />
            <Route path='/fetch-data' component={FetchData} />
        </Switch>
    </>
}

export default App;
