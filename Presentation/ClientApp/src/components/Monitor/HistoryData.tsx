import * as React from 'react';
import { useState } from 'react';
import { useLocation } from 'react-router';
import { API } from '../../tools/api';
import { Method, request } from '../../tools/request';
import { HistoryValues } from './models/HistoryData';

interface HistoryAttr {
    cottageId: string;
    placementType: string;
    cottageNumber: number;
}

const HistoryData: React.FunctionComponent = () => {

    const location = useLocation();

    const [cottageNumber, setCottageNumber] = useState<number>();
    const [placementType, setPlacementType] = useState<string>('');

    const [historyData, setHistoryData] = useState<HistoryValues[]>([]);
    const [loading, setLoading] = useState<boolean>(true);

    React.useEffect(() => {
        if (location.state) {
            const attr = location.state as HistoryAttr;
            setCottageNumber(attr.cottageNumber);
            setPlacementType(attr.placementType);

            (async () => {
                const data = await request(API.MONITOR + "/" + attr.placementType + "/" + attr.cottageId, undefined, Method.GET);

                setHistoryData(data);
                setLoading(false);
            })();
        }
    }, [location]);

    return <> {
        loading ? <p><em>Loading...</em></p> :
            <div>
                <h1 id="tabelLabel" >History. Cottage {cottageNumber}. Location: {placementType}</h1>
                <table className='table table-striped' aria-labelledby="tabelLabel">
                    <thead>
                        <tr>
                            <th>Date</th>
                            <th>Temperature</th>
                        </tr>
                    </thead>
                    <tbody>
                        {historyData.map(history =>
                            <tr key={history.id}>
                                <td>{history.changeTime}</td>
                                <td>{history.sensorValue}</td>
                            </tr>
                        )}
                    </tbody>
                </table>
        </div>
    }
    </>
}

export default HistoryData;