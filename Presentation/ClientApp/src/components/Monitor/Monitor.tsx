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
            <h1 id="tabelLabel" >Current values</h1>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Cottage number</th>
                            <th>Kitchen temperature</th>
                            <th>Hall temperature</th>
                            <th>Heating temperature</th>
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