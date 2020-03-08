import { FormGroup, TextInput } from 'carbon-components-react';
import * as React from 'react';
import { Page } from './Page';

export const SettingsPage: React.FunctionComponent<{}> = () => (
    <Page>
        <FormGroup legendText="Placeholder">
            <TextInput labelText="" id="state" />
            <TextInput labelText="" id="state" />
            <TextInput labelText="" id="state" />
        </FormGroup>
    </Page>
);
