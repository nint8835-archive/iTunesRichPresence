import * as React from 'react';
import { motion } from 'framer-motion';

const pageVariants = {
    initial: {
        scale: 0.8
    },
    in: {
        scale: 1
    },
    out: {
        scale: 0.5
    }
};
export const Page: React.FunctionComponent<{}> = ({ children }) => (
    <motion.div initial="initial" animate="in" exit="out" variants={pageVariants}>
        {children}
    </motion.div>
);
