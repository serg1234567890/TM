import * as React from 'react';
import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { API } from '../../tools/api';
import { Method, request } from '../../tools/request';
import { CottageData } from './models/CottageData';

const Monitor: React.FunctionComponent = () => {

    const navigate = useNavigate();
    const [cottageData, setCottageData] = useState<CottageData[]>([]);
    const [loading, setLoading] = useState<boolean>(true);

    React.useEffect(() => {
        (async () => {
            const data = await request(API.MONITOR, undefined, Method.GET);

            setCottageData(data);
            setLoading(false);
        })();
    }, []);

    const onClickHistory = (cottageId: string, cottageNumber: number, placementType: string) => {
        navigate("/History", { state: { cottageId: cottageId, cottageNumber: cottageNumber, placementType: placementType } });
    };

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
                                <td>{cottage.kitchenTemperature}<button className="btn" onClick={() => onClickHistory(cottage.id, cottage.cottageNumber, 'kitchen')}>History</button></td>
                                <td>{cottage.hallTemperature}<button className="btn" onClick={() => onClickHistory(cottage.id, cottage.cottageNumber, 'hall')}>History</button></td>
                                <td>{cottage.heatingTemperature}<button className="btn" onClick={() => onClickHistory(cottage.id, cottage.cottageNumber, 'heating')}>History</button></td>
                                <td></td>
                            </tr>
                        )}
                    </tbody>
                </table>
        </div>
    };
    </>
}

export default Monitor;