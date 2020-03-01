import { hot } from 'react-hot-loader/root';
import * as React from 'react';
import { NavBar } from './NavBar';
import './index.scss';

const Application = () => (
    <div>
        <NavBar />
    </div>
);

export default hot(Application);
