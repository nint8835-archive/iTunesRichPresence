import * as React from 'react';
import { Button } from 'carbon-components-react';
import { Token } from '../../../main/templating/types';

type TokenButtonPropTypes = {
    token: Token;
    lastFocusedText: string;
    setLastFocusedText: (text: string) => void;
};

export const TokenButton: React.FunctionComponent<TokenButtonPropTypes> = ({
    token,
    lastFocusedText,
    setLastFocusedText
}) => (
    <Button
        key={token.token}
        size="small"
        onClick={() => {
            setLastFocusedText(`${lastFocusedText}{{${token.token}}}`);
        }}
    >
        {token.displayName}
    </Button>
);
