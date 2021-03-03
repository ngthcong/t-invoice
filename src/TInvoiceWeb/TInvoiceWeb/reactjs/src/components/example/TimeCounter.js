import React from 'react'
import { connect } from 'unistore/react'
import { reducer } from '../../store/init'
import { Trans, useTranslation } from 'react-i18next'

const interval = 1000;

// The connect() function from unistore help to connect the store state (from /store/init.js)
// and notify the change to the component once the state is modified.
// For more information, visit: https://github.com/developit/unistore
const TimeCounter = connect('count', reducer)(
    ({ count, increaseCount, resetCount })=>{
        const {t} = useTranslation()
        // React useMemo to remember this value in the first render
        const second = React.useMemo(()=> interval / 1000, [])

        // useEffect will only be invoked when the increaseCount is changed or the component first mounted.
        React.useEffect(()=>{
            // Create a interval to increase the count every x miliseconds
            const timer = setInterval(()=>{
                increaseCount()
            }, interval)

            // The return result of useEffect callback must be a function
            // This function is used to clean up when the component is unmounted
            // If you don't clear the interval, the setInterval previously will still run even the component is unmounted
            return ()=>{
                clearInterval(timer)
            }
        }, [increaseCount])

        return <div>
            <p>
                <Trans count={count}>
                    Current {{count}}
                </Trans>
            </p>
            <h6>
                <Trans second={second}>
                    The count will be increased every {{second}} second(s)
                </Trans>
            </h6>
            <button onClick={resetCount}>
                {/* This one has the same effect with <Trans></Trans> component  */}
                {t("Refresh")}
            </button>
        </div>
    }
)

export default TimeCounter