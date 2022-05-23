import * as React from 'react';
import { useState } from 'react';
import { API } from '../../tools/api';
import { Method, request } from '../../tools/request';
import { CottageData } from './models/CottageData';

const FetchData: React.FunctionComponent = () => {

    const [cottageData, setCottageData] = useState<CottageData[]>([]);
    const [loading, setLoading] = useState<boolean>(true);

    React.useEffect(() => {
        (async () => {
            const data = await request(API.MONITOR, undefined, Method.GET);

            setCottageData(data);
            setLoading(false);
        })();
    }, []);

    return <> {
        loading ? <p><em>Loading...</em></p> :
        <div>
            <h1 id="tabelLabel" >Текущие показания</h1>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Номер коттеджа</th>
                            <th>Температура на кухне</th>
                            <th>Температура в коридоре</th>
                            <th>Температура отопления</th>
                        </tr>
                    </thead>
                    <tbody>
                        {cottageData.map(cottage =>
                            <tr key={cottage.id}>
                                <td>{cottage.cottageNumber}</td>
                                <td>{cottage.kitchenTemperature}</td>
                                <td>{cottage.hallTemperature}</td>
                                <td>{cottage.heatingTemperature}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
        </div>
    };
    </>
}

export default FetchData;