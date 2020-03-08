import { FormGroup, Tile } from 'carbon-components-react';
import * as React from 'react';
import { createUseStyles } from 'react-jss';
import tokens from '../../../main/templating/tokens';
import { TokenButton } from './TokenButton';

const useStyles = createUseStyles({
    toolboxGrid: {
        display: 'grid',
        gridTemplateColumns: '100%',
        gridGap: '0.5rem'
    }
});

type TokenToolboxPropTypes = {
    lastFocusedText: string;
    setLastFocusedText: (text: string) => void;
};

export const TokenToolbox: React.FunctionComponent<TokenToolboxPropTypes> = ({
    lastFocusedText,
    setLastFocusedText
}) => {
    const classes = useStyles();
    return (
        <Tile>
            <FormGroup legendText="Token Toolbox" style={{ marginBottom: 0 }}>
                <div className={classes.toolboxGrid}>
                    {tokens.map(token => (
                        <TokenButton
                            key={token.token}
                            token={token}
                            lastFocusedText={lastFocusedText}
                            setLastFocusedText={setLastFocusedText}
                        />
                    ))}
                </div>
            </FormGroup>
        </Tile>
    );
};
