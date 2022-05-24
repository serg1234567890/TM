import * as React from 'react';
import Chart from 'react-google-charts';
import { Modal, ModalBody, ModalHeader } from 'reactstrap';
import { API } from '../../tools/api';
import { Method, request } from '../../tools/request';
import { HistoryValues } from './models/HistoryData';

const HistoryChart: React.FunctionComponent<{ show: boolean, onSetShow?: () => void, cottageId: string, cottageNumber: number, placementType: string }> =
    ({ show, onSetShow, cottageId, cottageNumber, placementType }) => {

        const [loading, setLoading] = React.useState<boolean>(true);
        const [historyData, setHistoryData] = React.useState<HistoryValues[]>([]);
        const [history, setHistory] = React.useState<[string[], (string | number)[]]>([[], []]);

        React.useEffect(() => {
            (async () => {
                const data = await request(API.MONITOR + "/" + placementType + "/" + cottageId, undefined, Method.GET);

                setHistoryData(data);
                setLoading(false);
            })();
        }, [placementType, cottageId]);

        React.useEffect(() => {
            let arr: [string[], (string | number)[]] = [[], []];
            arr.splice(0, arr.length);
            arr.push(["Date", "Temperature"]);
            historyData.map((e) => {
                var item = ['', 0];
                item[0] = e.changeTime;
                item[1] = e.sensorValue;
                arr.push(item);
                return item;
            });
            console.log(arr);
            setHistory(arr);
        }, [historyData]);

        return <> {
            loading ? <p><em>Loading...</em></p> :
                <Modal isOpen={show} toggle={() => { if (onSetShow) onSetShow() }}>
                    <ModalHeader>
                        Temperature history. Cottage {cottageNumber}
                    </ModalHeader>
                    <ModalBody>
                        <Chart
                            chartType="ScatterChart"
                            data={history}
                            width="100%"
                            height="400px"
                            legendToggle
                        />
                    </ModalBody>
                </Modal>
        }</>
    }
export default HistoryChart;