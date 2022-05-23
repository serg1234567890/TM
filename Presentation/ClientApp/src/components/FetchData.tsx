import * as React from 'react';
import { useState } from 'react';
import { WeatherForecast } from './WeatherForecast';

const FetchData: React.FunctionComponent = () => {

    const [forecasts, setForecasts] = useState<WeatherForecast[]>([]);
    const [loading, setLoading] = useState<boolean>(true);

    const populateWeatherData = () => {
        (async () => {
            const response = await fetch('weatherforecast');
            const data = await response.json();

            setForecasts(data);
            setLoading(false);
        })();
    }

    React.useEffect(() => {
        populateWeatherData();
    }, []);

    return <> {
        loading ? <p><em>Loading...</em></p> :
        <div>
            <h1 id="tabelLabel" >Weather forecast</h1>
            <p>This component demonstrates fetching data from the server.</p>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Temp. (C)</th>
                            <th>Temp. (F)</th>
                            <th>Summary</th>
                        </tr>
                    </thead>
                    <tbody>
                        {forecasts.map(forecast =>
                            <tr key={''+forecast.date}>
                                <td>{''+forecast.date}</td>
                                <td>{forecast.temperatureC}</td>
                                <td>{forecast.temperatureF}</td>
                                <td>{forecast.summary}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
        </div>
    };
    </>
}

export default FetchData;