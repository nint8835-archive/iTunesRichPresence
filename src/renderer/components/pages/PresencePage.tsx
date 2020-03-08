import { FormGroup, TextInput, Tabs, Tab } from 'carbon-components-react';
import * as React from 'react';
import { Page } from './Page';
import { StateConfigEditor } from '../tokens/StateConfigEditor';
import { PlayerState } from '../../../main/itunes/types';

type PresencePagePropTypes = {
    playerState: PlayerState;
};

export const PresencePage: React.FunctionComponent<PresencePagePropTypes> = ({ playerState }) => (
    <Page>
        <StateConfigEditor playerState={playerState} />
    </Page>
);
