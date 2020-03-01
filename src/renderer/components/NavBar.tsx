import * as React from 'react';
import {
    Header,
    HeaderName,
    HeaderGlobalBar,
    HeaderGlobalAction
} from 'carbon-components-react/lib/components/UIShell';
import { Close20 } from '@carbon/icons-react';

export const NavBar: React.FunctionComponent<{}> = () => (
    // eslint-disable-next-line @typescript-eslint/ban-ts-ignore
    // @ts-ignore
    <Header style={{ '-webkit-app-region': 'drag' }}>
        <HeaderName prefix="">iTunesRichPresence</HeaderName>
        <HeaderGlobalBar>
            // @ts-ignore
            <HeaderGlobalAction style={{ '-webkit-app-region': 'no-drag' }} onClick={window.close}>
                <Close20 />
            </HeaderGlobalAction>
        </HeaderGlobalBar>
    </Header>
);
