import { FormGroup, Select, SelectItem, Checkbox } from 'carbon-components-react';
import * as React from 'react';
import { Page } from './Page';
import useLocalStorage from '../../hooks/useLocalStorage';
import { APP_IDS } from '../../../main/presence/PresenceManager';

export const SettingsPage: React.FunctionComponent<{}> = () => {
    const [selectedAppId, setSelectedAppId] = useLocalStorage<string>(
        'selectedAppId',
        APP_IDS.iTunes
    );
    const [displayPlaybackDuration, setDisplayPlaybackDuration] = useLocalStorage<boolean>(
        'displayPlaybackDuration',
        true
    );
    const [clearWhilePaused, setClearWhilePaused] = useLocalStorage<boolean>(
        'clearWhilePaused',
        true
    );
    const [launchOnStartup, setLaunchOnStartup] = useLocalStorage<boolean>('launchOnStartup', true);
    const [minimizeOnStartup, setMinimizeOnStartup] = useLocalStorage<boolean>(
        'minimizeOnStartup',
        true
    );
    return (
        <Page>
            <FormGroup legendText="App Name">
                <Select
                    id="selectedAppId"
                    labelText="This is the name of the app that will show up in Discord."
                    value={selectedAppId}
                    onChange={event => {
                        setSelectedAppId(event.target.value);
                    }}
                >
                    {Object.entries(APP_IDS).map(([name, appId]) => (
                        <SelectItem key={appId} value={appId} text={name} />
                    ))}
                </Select>
            </FormGroup>
            <FormGroup legendText="Display Options">
                <Checkbox
                    labelText="Display Playback Duration"
                    id="displayPlaybackDuration"
                    checked={displayPlaybackDuration}
                    onChange={setDisplayPlaybackDuration}
                />
                <Checkbox
                    labelText="Clear While Paused"
                    id="clearWhilePaused"
                    checked={clearWhilePaused}
                    onChange={setClearWhilePaused}
                />
            </FormGroup>
            <FormGroup legendText="Launch Options">
                <Checkbox
                    labelText="Launch on Startup"
                    id="launchOnStartup"
                    checked={launchOnStartup}
                    onChange={setLaunchOnStartup}
                />
                <Checkbox
                    labelText="Minimize on Startup"
                    id="minimizeOnStartup"
                    checked={minimizeOnStartup}
                    onChange={setMinimizeOnStartup}
                />
            </FormGroup>
        </Page>
    );
};
