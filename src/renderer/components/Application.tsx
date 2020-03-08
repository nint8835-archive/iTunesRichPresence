import { hot } from 'react-hot-loader/root';
import * as React from 'react';
import { Form, TextInput, Content, FormGroup, Button } from 'carbon-components-react';
import { WatsonHealthLaunchStudy_120 } from '@carbon/icons-react';
import { ipcRenderer } from 'electron';
import { NavBar } from './NavBar';
import './index.scss';

const Application = () => {
    const [stateText, setStateText] = React.useState('');
    const [detailsText, setDetailsText] = React.useState('');
    return (
        <div>
            <NavBar />
            <Content>
                <Form>
                    <FormGroup legendText="">
                        <TextInput
                            labelText="State"
                            id="state"
                            value={stateText}
                            onChange={e => {
                                setStateText(e.target.value);
                            }}
                            />
                    </FormGroup>
                    <FormGroup legendText="">
                        <TextInput
                            labelText="Details"
                            id="details"
                            value={detailsText}
                            onChange={e => {
                                setDetailsText(e.target.value);
                            }}
                            />
                    </FormGroup>
                    <Button
                        renderIcon={WatsonHealthLaunchStudy_120}
                        onClick={() => {
                            ipcRenderer.send('update-presence', stateText, detailsText);
                        }}>
                        Apply presence
                    </Button>
                </Form>
            </Content>
        </div>
    );
};

export default hot(Application);
